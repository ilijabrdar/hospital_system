using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller.decorators
{
    public class AuthorityRenovationDecoratorcs : IRenovationController
    {
        private IRenovationController RenovationController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityRenovationDecoratorcs(IRenovationController renovationController, String role)
        {
            this.RenovationController = renovationController;
            this.Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<string>() {"Director"};
            AuthorizedUsers["Edit"] = new List<string>() {"Director"};
            AuthorizedUsers["Get"] = new List<string>() {"Director"};
            AuthorizedUsers["GetAll"] = new List<string>() {"Director"};
            AuthorizedUsers["Save"] = new List<string>() {"Director"};
        }

        public void Delete(Renovation entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                RenovationController.Delete(entity);
        }

        public void Edit(Renovation entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                RenovationController.Edit(entity);
        }

        public Renovation Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
               return RenovationController.Get(id);
            return null;
        }

        public IEnumerable<Renovation> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return RenovationController.GetAll();
            return null;
        }

        public Renovation Save(Renovation entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return RenovationController.Save(entity);
            return null;
        }
    }
}
