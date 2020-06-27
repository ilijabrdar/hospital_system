using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Doctor;
using Model.Users;

namespace bolnica.Controller.decorators
{
    public class AuthorityHospitalizationDecorator : IHospitalizationController
    {
        private IHospitalizationController HospitalizationController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityHospitalizationDecorator(IHospitalizationController hospitalizationController, string role)
        {
            HospitalizationController = hospitalizationController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Edit"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Get"] = new List<String>() { "Doctor", "Patient" };
            AuthorizedUsers["GetAll"] = new List<String>() { "Doctor", "Patient" };
            AuthorizedUsers["GetHospitalizationByDoctor"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Save"] = new List<String>() { "Doctor" };
        }

        public void Delete(Hospitalization entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                HospitalizationController.Delete(entity);
        }

        public void Edit(Hospitalization entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                HospitalizationController.Edit(entity);
        }

        public Hospitalization Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return HospitalizationController.Get(id);
            else
                return null;
        }

        public IEnumerable<Hospitalization> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return HospitalizationController.GetAll();
            else
                return null;
        }

        public List<Hospitalization> GetHospitalizationByDoctor(Doctor doctor)
        {
            if (AuthorizedUsers["GetHospitalizationByDoctor"].SingleOrDefault(x => x == Role) != null)
                return HospitalizationController.GetHospitalizationByDoctor(doctor);
            else
                return null;
        }

        public Hospitalization Save(Hospitalization entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return HospitalizationController.Save(entity);
            else
                return null;
        }
    }
}
