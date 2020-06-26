using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Doctor;

namespace bolnica.Controller.decorators
{
    public class AuthoritySpecialityDecorator : ISpecialityController
    {
        private ISpecialityController SpecialityController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;
        public AuthoritySpecialityDecorator(ISpecialityController specialityController, string role)
        {
            SpecialityController = specialityController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Get"] = new List<String>() { "Patient", "Doctor", "Director" };
            AuthorizedUsers["GetAll"] = new List<String>() { "Patient", "Doctor", "Director" };

        }

        public Speciality Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return SpecialityController.Get(id);
            else
                return null;
        }

        public IEnumerable<Speciality> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return SpecialityController.GetAll();
            else
                return null;
        }
    }
}
