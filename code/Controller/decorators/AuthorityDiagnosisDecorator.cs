using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.PatientSecretary;

namespace bolnica.Controller.decorators
{
    public class AuthorityDiagnosisDecorator : IDiagnosisController
    {
        private IDiagnosisController DiagnosisController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;
        public AuthorityDiagnosisDecorator(IDiagnosisController diagnosisController, string role)
        {
            DiagnosisController = diagnosisController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Get"] = new List<String>() { "Doctor" };
            AuthorizedUsers["GetAll"] = new List<String>() { "Doctor" };
        }

        public Diagnosis Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return DiagnosisController.Get(id);
            else
                return null;
        }

        public IEnumerable<Diagnosis> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return DiagnosisController.GetAll();
            else
                return null;
        }
    }
}
