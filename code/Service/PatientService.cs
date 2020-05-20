/***********************************************************************
 * Module:  PatientService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using Model.Users;
using System;

namespace Service
{
   public class PatientService : IService
   {
      public Patient ClaimAccount(String jmbg)
      {
         // TODO: implement
         return null;
      }

        public object Save()
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

        private Repository.IPatientRepository _patientRepository;
   
   }
}