using Controller;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public interface IPatientFileController : IController<PatientFile,long>
{
        PatientFile GetPatientFile(Patient patient);

        Examination AddExamination(Examination examination, PatientFile patientFile);
        Hospitalization AddHospitalization(Hospitalization hospitalization, PatientFile patientFile);
        Operation AddOperation(Operation operations, PatientFile patientFile);
        Allergy AddAllergy(Allergy allergy, PatientFile patientFile);
        Boolean DeleteAllergy(Allergy allergy, PatientFile patientFile);

    }
}
