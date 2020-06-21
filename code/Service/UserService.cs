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
        public bool BlockUser(string username)
        {
            throw new NotImplementedException();
        }

        public object Delete()
        {
            throw new NotImplementedException();
        }

        public void Edit(User entity)
        {
            Doctor doktor = (Doctor)entity;
            _doctorService.Edit(doktor);

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
         //   if ((user = _patientService.GetUserByUsername(username)) != null)
          //      return user;
          ////  if ((user = _secretaryService.GetUserByUsername(username)) != null)
            //    return user;
            //else if ((user = _directorService.GetUserByUsername(username)) != null)
            //    return user;
            if ((user = _doctorService.GetUserByUsername(username)) != null)
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

        public bool Logout(User user)
        {
            throw new NotImplementedException();
        }


        public Feedback SendFeedback(string feedback)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Get(long id)
        {
            User user = null;
            if ((user = _doctorService.Get(id)) != null)
                return user;

            return user;
        }

        public bool IsPasswordValid(string password)
        {
            throw new NotImplementedException();
        }
    }
}
