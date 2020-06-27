using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller.decorators
{
    public class AuthorityDrugDecorator : IDrugController
    {
        private IDrugController DrugController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityDrugDecorator(IDrugController drugController, String role)
        {
            this.DrugController = drugController;
            this.Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["ApproveDrug"] = new List<string>() { "Doctor" };
            AuthorizedUsers["CheckDrugNameUnique"] = new List<string>() { "Director" };
            AuthorizedUsers["Delete"] = new List<string>() { "Director" };
            AuthorizedUsers["Edit"] = new List<string>() { "Director", "Doctor" };
            AuthorizedUsers["Get"] = new List<string>() { "Director", "Doctor" };
            AuthorizedUsers["GetAll"] = new List<string>() { "Director", "Doctor" };
            AuthorizedUsers["GetNotApprovedDrugs"] = new List<string>() { "Doctor" };
            AuthorizedUsers["Save"] = new List<string>() { "Director" };
        }

        public bool CheckDrugNameUnique(string name)
        {
            if (AuthorizedUsers["CheckDrugNameUnique"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DrugController.CheckDrugNameUnique(name);
            return false;
        }

        public void Delete(Drug entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                DrugController.Delete(entity);
        }

        public void Edit(Drug entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                DrugController.Edit(entity);
        }

        public Drug Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DrugController.Get(id);
            return null;
        }

        public IEnumerable<Drug> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DrugController.GetAll();
            return null;
        }


        public List<Drug> GetNotApprovedDrugs()
        {
            if (AuthorizedUsers["GetNotApprovedDrugs"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DrugController.GetNotApprovedDrugs();
            return null;
        }

        public Drug Save(Drug entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DrugController.Save(entity);
            return null;
        }
    }
}
