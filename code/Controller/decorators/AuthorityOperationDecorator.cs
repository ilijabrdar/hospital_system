using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Doctor;
using Model.Users;

namespace bolnica.Controller.decorators
{
    public class AuthorityOperationDecorator : IOperationController
    {
        private IOperationController OperationController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityOperationDecorator(IOperationController operationController, string role)
        {
            OperationController = operationController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<String>() { "Doctor", "Secretary" };
            AuthorizedUsers["Edit"] = new List<String>() { "Doctor", "Secretary" };
            AuthorizedUsers["Get"] = new List<String>() { "Secretary", "Doctor", "Patient" };
            AuthorizedUsers["GetAll"] = new List<String>() { "Secretary", "Doctor", "Patient" };
            AuthorizedUsers["GetOperationsByDoctor"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Save"] = new List<String>() { "Doctor" };
        }

        public void Delete(Operation entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                OperationController.Delete(entity);

        }

        public void Edit(Operation entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                OperationController.Edit(entity);
        }

        public Operation Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return OperationController.Get(id);
            else
                return null;
        }

        public IEnumerable<Operation> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return OperationController.GetAll();
            else
                return null;
        }

        public List<Operation> GetOperationsByDoctor(Doctor doctor)
        {
            if (AuthorizedUsers["GetOperationsByDoctor"].SingleOrDefault(x => x == Role) != null)
                return OperationController.GetOperationsByDoctor(doctor);
            else
                return null;
        }

        public Operation Save(Operation entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return OperationController.Save(entity);
            else
                return null;
        }
    }
}
