/***********************************************************************
 * Module:  PatientService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using Model.Users;
using System;

namespace Repository
{
   public class PatientRepository : IPatientRepository
   {
      private String FilePath;

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

        public Patient GetPatientByJMBG(string jmbg)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public object Save()
        {
            throw new NotImplementedException();
        }
    }
}