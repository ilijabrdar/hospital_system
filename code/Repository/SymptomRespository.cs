
using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
    public class SymptomRespository : CSVRepository<Symptom,long>, ISymptomRepository
    {
        public SymptomRespository(ICSVStream<Symptom> stream, ISequencer<long> sequencer)
          : base(stream, sequencer)
        {

        }
    }
}
