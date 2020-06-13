using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IPatientFileService : IService<PatientFile, long>
{
        PatientFile GetPatientFile(Patient patient);

        Examination AddExamination(Examination examination, PatientFile patientFile);


        Hospitalization AddHospitalization(Hospitalization hospitalization, PatientFile patientFile);

         Operation AddOperation(Operation operation, PatientFile patientFile);

        Allergy AddAllergy(Allergy allergy, PatientFile patientFile);
        Boolean DeleteAllergy(PatientFile patientFile, Allergy allergy);

    }
}
