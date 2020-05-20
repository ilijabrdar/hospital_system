/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DoctorService
 ***********************************************************************/

using Model.Doctor;
using Model.Users;
using System;

namespace Repository
{
   public class DoctorRepository : IDoctorRepository
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

        public Doctor GetDoctorByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Doctor[] GetDoctorsBySpeciality(Specialty specialty)
        {
            throw new NotImplementedException();
        }

        public object Save()
        {
            throw new NotImplementedException();
        }
    }
}