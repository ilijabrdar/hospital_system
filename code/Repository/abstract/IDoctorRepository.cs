using bolnica.Repository;
using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IDoctorRepository : IRepository<Doctor,long>, IEagerRepository<Doctor, long>, IUserGetterRepository
   {
      List<Doctor> GetDoctorsBySpeciality(Speciality specialty);
   }
}