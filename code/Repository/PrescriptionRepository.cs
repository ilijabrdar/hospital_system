using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
     public class PrescriptionRepository : CSVRepository<Prescription, long>, IPrescriptionRepository
    {
        public PrescriptionRepository(ICSVStream<Prescription> stream, ISequencer<long> sequencer)
          : base(stream, sequencer)
        {

        }
    }
}
