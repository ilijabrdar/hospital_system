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
   public class RefferalRepository : CSVRepository<Referral, long>, IReferralRepository
    {
        public RefferalRepository(ICSVStream<Model.Doctor.Referral> stream, ISequencer<long> sequencer)
          : base(stream, sequencer)
        {

        }
    }
}
