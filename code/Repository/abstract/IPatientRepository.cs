

using bolnica.Repository;
using Model.Users;
using System;

namespace Repository
{
   public interface IPatientRepository : IRepository<Patient, long>, IUserGetterRepository, IEagerRepository<Patient, long>
    {
      Patient GetPatientByJMBG(String jmbg);
   }
}