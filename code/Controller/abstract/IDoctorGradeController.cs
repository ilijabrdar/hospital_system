using Controller;
using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{ 
  public  interface IDoctorGradeController : IController<DoctorGrade,long>
    {
        double GetAverageGrade(Doctor doctor);

    }
}
