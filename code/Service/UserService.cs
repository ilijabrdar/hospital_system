/***********************************************************************
 * Module:  UserService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.UserService
 ***********************************************************************/

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
        private IDoctorService _doctorService;
        private IPatientService _patientService;
        private ISecretaryService _secretaryService;
        private IDirectorService _directorService;

        private readonly IPatientFileRepository _patientFileRepo;
        public UserService(IPatientService patientServ, IDoctorService _doctor, ISecretaryService secretaryService, IDirectorService directorService)
        {
            this._patientService = patientServ;
            this._doctorService = _doctor;
            _secretaryService = secretaryService;
            _directorService = directorService;
        }
        public UserService(IPatientService patientService)
        {
            this._patientService = patientService;
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

        public object Edit()
        {
            throw new NotImplementedException();
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }

        public bool IsPasswordValid(User user, String password)
        {
            if (user.Password != password)
                return false;
            else
                return true;
        }

        // TODO: Zasto svaka rola ima svoju get<>ByID, Zasto to nije u Useru??
        public User IsUsernameValid(string username)
        {
            User user = null;
            //if ((user = _patientService.GetPatientByUsername(username)) != null)
            //    return user;
            if ((user = _secretaryService.GetSecretaryByUsername(username)) != null)
                return user;
            //else if ((user = _directorService.GetDirectorByUsername(username)) != null)
            //    return user;
            //else if ((user = _doctorService.GetDoctorByUsername(username)) != null)
            //    return user;
            //else if ((user = _directorRepo.GetDirectorByUsername(username)) != null)
            //    return user;
            //else if ((user = _doctorRepo.GetDoctorByUsername(username)) != null)
            //    return user;
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

        public void Edit(User entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IService<User, long>.GetAll()
        {
            throw new NotImplementedException();
        }

        public User Get(long id)
        {
            throw new NotImplementedException();
        }

        public bool IsPasswordValid(string password)
        {
            throw new NotImplementedException();
        }
    }
}