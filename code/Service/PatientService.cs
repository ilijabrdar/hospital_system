/***********************************************************************
 * Module:  PatientService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using bolnica.Service;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class PatientService : IPatientService
   {
        
        private readonly IPatientRepository _patientRepository;
        private readonly IPatientFileService _patientFileService;

        public PatientService(IPatientRepository _patientRepo, IPatientFileService _servicePatientFile)
        {
            _patientRepository = _patientRepo;
            _patientFileService = _servicePatientFile;
        }

        public Patient Save(Patient entity)
        {
            if (_patientRepository.GetPatientByUsername(entity.Username) != null)
            {
                return null;
            }
            //TODO: skloniti -1 iz patFile
            entity.patientFile = _patientFileService.Save(new PatientFile(-1));
            return _patientRepository.Save(entity);

        }

        public void Delete(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Patient entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Patient Get(long id)
        {
            throw new NotImplementedException();
        }

        public Patient ClaimAccount(long id)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientByUsername(string username)
        {
            return _patientRepository.GetPatientByUsername(username);
        }
    }
}