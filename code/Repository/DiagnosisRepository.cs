using bolnica.Repository;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class DiagnosisRepository : CSVRepository<Diagnosis, long>, IDiagnosisRepository
    {
        public DiagnosisRepository(ICSVStream<Diagnosis> stream, ISequencer<long> sequencer)
          : base(stream, sequencer)
        {

        }
    }
}
