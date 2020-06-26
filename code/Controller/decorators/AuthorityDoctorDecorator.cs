using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller.decorators
{
    public class AuthorityDoctorDecorator : IDoctorController
    {
        private IDoctorController DoctorController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityDoctorDecorator(IDoctorController doctorController, String role)
        {
            this.DoctorController = doctorController;
            this.Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["CheckJMBGUnique"] = new List<string>() { "Director" };
            AuthorizedUsers["Delete"] = new List<string>() { "Director" };
            AuthorizedUsers["Edit"] = new List<string>() { "Director", "Doctor"};
            AuthorizedUsers["Get"] = new List<string>() { "Director", "Doctor", "Secretary" };
            AuthorizedUsers["GetAll"] = new List<string>() { "Director", "Doctor", "Secretary" };
            AuthorizedUsers["GetDoctorsBySpeciality"] = new List<string>() { "Doctor", "Patient" };
            AuthorizedUsers["Save"] = new List<string>() { "Director" };

        }

        public bool CheckJMBGUnique(string JMBG)
        {
            if (AuthorizedUsers["CheckJMBGUnique"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DoctorController.CheckJMBGUnique(JMBG);
            return false;
        }

        public void Delete(Doctor entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                DoctorController.Delete(entity);
        }

        public void Edit(Doctor entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                DoctorController.Edit(entity);
        }

        public Doctor Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DoctorController.Get(id);
            return null;
        }

        public IEnumerable<Doctor> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DoctorController.GetAll();
            return null;
        }

        public List<Doctor> GetDoctorsBySpeciality(Speciality specialty)
        {
            if (AuthorizedUsers["GetDoctorsBySpeciality"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DoctorController.GetDoctorsBySpeciality(specialty);
            return null;
        }

        public Doctor Save(Doctor entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return DoctorController.Save(entity);
            return null;
        }
    }
}
