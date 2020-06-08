using Model.Doctor;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
   public interface IDoctorService : IService<Doctor, long>
    {
    List<Doctor> GetDoctorsBySpeciality(Speciality specialty);
       Doctor GetDoctorByUsername(String username);
    }
}
