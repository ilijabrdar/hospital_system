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
        public DiagnosisRepository(ICSVStream<Diagnosis> stream, ISequencer<long> sequencer)
          : base(stream, sequencer)
        {

        }

        public IEnumerable<Diagnosis> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Diagnosis GetEager(long id)
        {
            throw new NotImplementedException();
        }
    }
}
