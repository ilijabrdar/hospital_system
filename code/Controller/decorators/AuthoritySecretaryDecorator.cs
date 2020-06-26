using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller.decorators
{
    public class AuthoritySecretaryDecorator : ISecretaryController
    {
        private ISecretaryController SecretaryController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthoritySecretaryDecorator(ISecretaryController secretaryController, String role)
        {
            this.SecretaryController = secretaryController;
            this.Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<string>() { "Secretary" };
            AuthorizedUsers["Edit"] = new List<string>() { "Secretary" };
            AuthorizedUsers["Get"] = new List<string>() { "Secretary" };
            AuthorizedUsers["GetAll"] = new List<string>() { "Secretary" };
            AuthorizedUsers["Save"] = new List<string>() { "Secretary" };
        }

        public void Delete(Secretary entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                SecretaryController.Delete(entity);
        }

        public void Edit(Secretary entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                SecretaryController.Edit(entity);
        }

        public Secretary Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return SecretaryController.Get(id);
            return null;
        }

        public IEnumerable<Secretary> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return SecretaryController.GetAll();
            return null;
        }

        public Secretary Save(Secretary entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return SecretaryController.Save(entity);
            return null;
        }
    }
}
