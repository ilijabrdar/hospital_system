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

    
        
    }
}
