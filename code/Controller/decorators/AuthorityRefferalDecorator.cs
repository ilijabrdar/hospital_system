using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Doctor;

namespace bolnica.Controller.decorators
{
    public class AuthorityRefferalDecorator : IReferralController
    {
        private IReferralController ReferralController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityRefferalDecorator(IReferralController referralController, string role)
        {
            ReferralController = referralController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Edit"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Get"] = new List<String>() { "Doctor" };
            AuthorizedUsers["GetAll"] = new List<String>() { "Doctor" };
            AuthorizedUsers["Save"] = new List<String>() { "Doctor" };
        }

        public void Delete(Referral entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                ReferralController.Delete(entity);
        }

        public void Edit(Referral entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                ReferralController.Edit(entity);
        }

        public Referral Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return ReferralController.Get(id);
            else
                return null;
        }

        public IEnumerable<Referral> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return ReferralController.GetAll();
            else
                return null;
        }

        public Referral Save(Referral entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return ReferralController.Save(entity);
            else
                return null;
        }
    }
}
