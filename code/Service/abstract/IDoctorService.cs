using Model.Doctor;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
   public interface IDoctorService : IService<Doctor, long>, IUserGetterService
    {
    List<Doctor> GetDoctorsBySpeciality(Speciality specialty);

        void DeleteBusinessDayFromDoctor(BusinessDay businessDay);

        bool CheckJMBGUnique(String JMBG);
    }
}
