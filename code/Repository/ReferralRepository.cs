using bolnica.Repository;
using bolnica.Service;
using Model.Doctor;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ReferralRepository : CSVRepository<Referral, long>, IReferralRepository
    {
        public ReferralRepository(ICSVStream<Model.Doctor.Referral> stream, ISequencer<long> sequencer)
          : base(stream, sequencer)
        {

        }

        public IEnumerable<Referral> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Referral GetEager(long id)
        {
            throw new NotImplementedException();
        }
    }
}
