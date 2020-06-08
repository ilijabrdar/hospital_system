using bolnica.Repository;
using Model.Doctor;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
   public interface IReferralRepository : IRepository<Referral,long> , IEagerRepository<Referral, long>
    {
    }
}
