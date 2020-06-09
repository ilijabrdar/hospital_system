

using bolnica.Repository;
using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class HospitalizationRepository : CSVRepository<Hospitalization, long>, IHospitalizationRepository
    {
      private String FilePath;
        public HospitalizationRepository(ICSVStream<Hospitalization> stream, ISequencer<long> sequencer)
            : base(stream, sequencer)
        {

        }

        public IEnumerable<Hospitalization> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Hospitalization GetEager(long id)
        {
            throw new NotImplementedException();
        }
    }
}