using Controller;
using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
   public interface IPatientController : IController<Patient, long>
    {
        Patient GetPatientByJMBG(String jmbg);

        Patient ClaimAccount(String jmbg);

        DoctorGrade GiveGradeToDoctor(Doctor doctor, Dictionary<String, double> gradesForDoctor);
    }
}
