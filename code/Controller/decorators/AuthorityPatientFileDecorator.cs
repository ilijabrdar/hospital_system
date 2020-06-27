using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;

namespace bolnica.Controller.decorators
{
    public class AuthorityPatientFileDecorator : IPatientFileController
    {
        private IPatientFileController PatientFileController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityPatientFileDecorator(IPatientFileController patientFileController, string role)
        {
            PatientFileController = patientFileController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["AddAllergy"] = new List<String>() { "Doctor" };
            AuthorizedUsers["AddExamination"] = new List<String>() { "Doctor" };
            AuthorizedUsers["AddHospitalization"] = new List<String>() { "Doctor" };
            AuthorizedUsers["AddOperation"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Delete"] = new List<String>() { "Doctor" };
            AuthorizedUsers["DeleteAllergy"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Edit"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Get"] = new List<String>() { "Patient", "Doctor" };
            AuthorizedUsers["GetAll"] = new List<String>() { "Patient", "Doctor" };
            AuthorizedUsers["GetPatientFile"] = new List<String>() { "Patient", "Doctor" };
            AuthorizedUsers["Save"] = new List<String>() { "Doctor" };
        }
        public Allergy AddAllergy(Allergy allergy, PatientFile patientFile)
        {
            if (AuthorizedUsers["AddAllergy"].SingleOrDefault(x => x == Role) != null)
                return PatientFileController.AddAllergy(allergy, patientFile);
            else
                return null;
        }

        public Examination AddExamination(Examination examination, PatientFile patientFile)
        {
            if (AuthorizedUsers["AddExamination"].SingleOrDefault(x => x == Role) != null)
                return PatientFileController.AddExamination(examination, patientFile);
            else
                return null;
        }

        public Hospitalization AddHospitalization(Hospitalization hospitalization, PatientFile patientFile)
        {
            if (AuthorizedUsers["AddHospitalization"].SingleOrDefault(x => x == Role) != null)
                return PatientFileController.AddHospitalization(hospitalization, patientFile);
            else
                return null;
        }

        public Operation AddOperation(Operation operations, PatientFile patientFile)
        {
            if (AuthorizedUsers["AddOperation"].SingleOrDefault(x => x == Role) != null)
                return PatientFileController.AddOperation(operations, patientFile);
            else
                return null;
        }

        public void Delete(PatientFile entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                PatientFileController.Delete(entity);
 
        }

        public bool DeleteAllergy(Allergy allergy, PatientFile patientFile)
        {
            if (AuthorizedUsers["DeleteAllergy"].SingleOrDefault(x => x == Role) != null)
                return PatientFileController.DeleteAllergy(allergy, patientFile);
            else
                return false;
        }

        public void Edit(PatientFile entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                PatientFileController.Edit(entity);
        }

        public PatientFile Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return PatientFileController.Get(id);
            else
                return null;
        }

        public IEnumerable<PatientFile> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return PatientFileController.GetAll();
            else
                return null;
        }

        public PatientFile GetPatientFile(Patient patient)
        {
            if (AuthorizedUsers["GetPatientFile"].SingleOrDefault(x => x == Role) != null)
                return PatientFileController.GetPatientFile(patient);
            else
                return null;
        }

        public PatientFile Save(PatientFile entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return PatientFileController.Save(entity);
            else
                return null;
        }
    }
}
