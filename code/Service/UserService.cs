using bolnica.Service;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly ISecretaryService _secretaryService;
        private readonly IDirectorService _directorService;

        public UserService(IPatientService patientServ, IDoctorService _doctor, ISecretaryService secretaryService, IDirectorService directorService)
        {
            _patientService = patientServ;
            _doctorService = _doctor;
            _secretaryService = secretaryService;
            _directorService = directorService;
        }
        public UserService(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public User Save(User entity)
        {
            try
            {
                Patient patient = (Patient)entity;
                return _patientService.Save(patient);

            }
            catch
            {
                Doctor docktor = (Doctor)entity;
                return _doctorService.Save(docktor);
            }
        }

        public void Edit(User entity)
        {
            if (entity.GetType() == typeof(Doctor))
            {
                _doctorService.Edit((Doctor)entity);
            }
            else if(entity.GetType() == typeof(Patient))
            {
                _patientService.Edit((Patient)entity);
            }
            else if(entity.GetType() == typeof(Secretary))
            {
                _secretaryService.Edit((Secretary)entity);
            }
            else if(entity.GetType() == typeof(Director))
            {
                _directorService.Edit((Director)entity);
            }
        }

        public bool IsPasswordValid(User user, String password)
        {
            if (user.Password != password)
                return false;
            else
                return true;
        }

        public User IsUsernameValid(string username)
        {
            User user = null;

            if ((user = _patientService.GetUserByUsername(username)) != null)
                return user;
            else if ((user = _secretaryService.GetUserByUsername(username)) != null)
                return user;
            else if ((user = _directorService.GetUserByUsername(username)) != null)
                return user;
            else if ((user = _doctorService.GetUserByUsername(username)) != null)
               return user;

            return user;
        }

        public User Login(string username, string password)
        {
            User user = IsUsernameValid(username);
            if (user != null)
                return IsPasswordValid(user, password) ? user : null;
            else
                return null;
        }

        public void Delete(User entity)
        {
            if (entity.GetType() == typeof(Doctor))
                _doctorService.Delete((Doctor)entity);
            if (entity.GetType() == typeof(Director))
                _directorService.Delete((Director)entity);
            if (entity.GetType() == typeof(Secretary))
                _secretaryService.Delete((Secretary)entity);
            if (entity.GetType() == typeof(Patient))
                _patientService.Delete((Patient)entity);          
        }

        public IEnumerable<User> GetAll()
        {
            return null;
        }

        public User Get(long id)
        {
            return null;
        }
    }
}
