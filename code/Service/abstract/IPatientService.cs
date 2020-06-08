using Model.Doctor;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IPatientService : IService<Patient, long>
{
        Patient ClaimAccount(String id);
        Patient GetPatientByUsername(String username);

        Patient GetPatientByJMBG(String jmbg);

        DoctorGrade GiveGrade(Doctor doctor, Dictionary<String, double> gradesForDoctor);

    }
}
