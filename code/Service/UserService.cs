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
        //private IService _doctorService;
        //private IService _patientService;
        //private IService _secretaryService;
        //private IService _directorService;
        
        //TODO : u klas dijagram dodati ove veze ako vam se ovo svidja
        private readonly IPatientRepository _patientRepo;
        private readonly IPatientFileRepository _patientFileRepo;

        public UserService(IPatientRepository patientRepo, IPatientFileRepository fileRepo)
        {
            this._patientRepo = patientRepo;
            this._patientFileRepo = fileRepo;
        }

        public User Save(User entity)
        {
            try
            {
                Patient patient = (Patient)entity;
                if (_patientRepo.GetPatientByUsername(patient.Username).Equals(null)){
                    return null;
                }
                patient.patientFile = _patientFileRepo.Save(new PatientFile(-1));
                return _patientRepo.Save(patient);

            }
            catch
            {
                Doctor docktor = (Doctor)entity;
                // TODO : imam jos nekih pitanja oko doktora 
                return null;
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

        public bool IsPasswordValid(string password)
        {
            throw new NotImplementedException();
        }

        public bool IsUsernameValid(string username)
        {
            throw new NotImplementedException();
        }

        public User Login(string username, string password)
        {
            throw new NotImplementedException();
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
    }
}