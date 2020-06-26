using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.PatientSecretary;

namespace bolnica.Controller.decorators
{
    public class AuthorityTherapyDecorator : ITherapyController
    {
        private ITherapyController TherapyController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityTherapyDecorator(ITherapyController therapyController, string role)
        {
            TherapyController = therapyController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["AssignCurrentTherapy"] = new List<String>() { "Patient" };
            AuthorizedUsers["Delete"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Edit"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Get"] = new List<String>() { "Doctor" };
            AuthorizedUsers["GetAll"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Save"] = new List<String>() { "Doctor" };
        }

        public Therapy AssignCurrentTherapy(PatientFile patientFile)
        {
            if (AuthorizedUsers["AssignCurrentTherapy"].SingleOrDefault(x => x == Role) != null)
                return TherapyController.AssignCurrentTherapy(patientFile);
            else
                return null;
        }

        public void Delete(Therapy entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                TherapyController.Delete(entity);
        }

        public void Edit(Therapy entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                TherapyController.Edit(entity);
        }

        public Therapy Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return TherapyController.Get(id);
            else
                return null;
        }

        public IEnumerable<Therapy> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return TherapyController.GetAll();
            else
                return null;
        }

        public Therapy Save(Therapy entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return TherapyController.Save(entity);
            else
                return null;
        }
    }
}
