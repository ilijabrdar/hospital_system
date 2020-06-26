using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.PatientSecretary;

namespace bolnica.Controller.decorators
{
    public class AuthorityPrescriptionDecorator : IPrescriptionController
    {
        private IPrescriptionController PrescriptionController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityPrescriptionDecorator(IPrescriptionController prescriptionController, string role)
        {
            PrescriptionController = prescriptionController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Edit"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Get"] = new List<String>() { "Doctor" };
            AuthorizedUsers["GetAll"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Save"] = new List<String>() { "Doctor" };
        }
        public void Delete(Prescription entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                PrescriptionController.Delete(entity);
        }

        public void Edit(Prescription entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                PrescriptionController.Edit(entity);
        }

        public Prescription Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return PrescriptionController.Get(id);
            else
                return null;
        }

        public IEnumerable<Prescription> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return PrescriptionController.GetAll();
            else
                return null;
        }

        public Prescription Save(Prescription entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return PrescriptionController.Save(entity);
            else
                return null;
        }
    }
}
