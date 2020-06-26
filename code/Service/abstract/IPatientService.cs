using Model.Doctor;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IPatientService : IService<Patient, long>, IUserGetterService
{
        Patient ClaimAccount(Patient patient);

        Patient GetPatientByJMBG(String jmbg);

        DoctorGrade GiveGradeToDoctor(Doctor doctor, Dictionary<String, double> gradesForDoctor);

    }
}
