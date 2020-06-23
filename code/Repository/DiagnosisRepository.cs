using bolnica.Repository;
using bolnica.Repository.CSV;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class DiagnosisRepository : CSVGetterRepository<Diagnosis, long>, IDiagnosisRepository
    {
        private readonly ISymptomRepository _symptomRepo;

        public DiagnosisRepository(ICSVStream<Diagnosis> stream, ISequencer<long> sequencer, ISymptomRepository _symptomRepository)
          : base(stream, sequencer)
        {
            _symptomRepo = _symptomRepository;
        }

        public IEnumerable<Diagnosis> GetAllEager()
        {
            List<Diagnosis> diagnosis = new List<Diagnosis>();
            foreach(Diagnosis diag in GetAll().ToList())
            {
                diagnosis.Add(GetEager(diag.GetId()));
            }
            return diagnosis;
        }

        public Diagnosis GetEager(long id)
        {
            Diagnosis diagnosis = Get(id);

            foreach (Symptom symptom in diagnosis.Symptom) {
                Symptom temp = _symptomRepo.Get(symptom.Id);
                symptom.Name = temp.Name;
            }
            return diagnosis;
        }
    }
}
