using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.PatientSecretary;

namespace bolnica.Controller.decorators
{
    public class AuthoritySympthomDecorator : ISymptomController
    {
        private ISymptomController SymptomController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;
        public AuthoritySympthomDecorator(ISymptomController symptomController, string role)
        {
            SymptomController = symptomController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Edit"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Get"] = new List<String>() { "Doctor" };
            AuthorizedUsers["GetAll"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Save"] = new List<String>() { "Doctor" };
        }

        public void Delete(Symptom entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                SymptomController.Delete(entity);
        }

        public void Edit(Symptom entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                SymptomController.Edit(entity);
        }

        public Symptom Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return SymptomController.Get(id);
            else
                return null;
        }

        public IEnumerable<Symptom> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return SymptomController.GetAll();
            else
                return null;
        }

        public Symptom Save(Symptom entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return SymptomController.Save(entity);
            else
                return null;
        }
    }
}
