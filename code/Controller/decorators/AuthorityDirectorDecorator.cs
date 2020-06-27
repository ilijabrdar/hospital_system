using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller.decorators
{
    public class AuthorityDirectorDecorator : IDirectorController
    {
        private IDirectorController DirectorController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityDirectorDecorator(IDirectorController directorController, String role)
        {
            this.DirectorController = directorController;
            this.Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<string>() { "Director" };
            AuthorizedUsers["Edit"] = new List<string>() { "Director" };
            AuthorizedUsers["Get"] = new List<string>() { "Director" };
            AuthorizedUsers["GetAll"] = new List<string>() { "Director" };
            AuthorizedUsers["RegisterDoctor"] = new List<string>() { "Director" };
            AuthorizedUsers["Save"] = new List<string>() { "Director" };
        }

        public void Delete(Director entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                DirectorController.Delete(entity);
        }

        public void Edit(Director entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                DirectorController.Edit(entity);
        }

        public Director Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DirectorController.Get(id);
            return null;
        }

        public IEnumerable<Director> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DirectorController.GetAll();
            return null;
        }


        public Director Save(Director entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DirectorController.Save(entity);
            return null;
        }
    }
}
