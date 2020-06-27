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
        private readonly ISymptomRepository _symptomRepository;

        public DiagnosisRepository(ICSVStream<Diagnosis> stream, ISequencer<long> sequencer, ISymptomRepository symptomRepository)
          : base(stream, sequencer)
        {
            this._symptomRepository = symptomRepository;
        }
    }
}
