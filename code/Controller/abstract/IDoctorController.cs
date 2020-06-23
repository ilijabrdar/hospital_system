using Controller;
using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
   public interface IDoctorController : IController<Doctor, long>
    {
         List<Doctor> GetDoctorsBySpeciality(Speciality specialty);

        bool CheckJMBGUnique(String JMBG);


    }
}
