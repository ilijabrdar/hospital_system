/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DoctorService
 ***********************************************************************/

using Model.Doctor;
using System;

namespace Service
{
   public class DoctorService : IService
   {
      public Model.Users.Doctor[] GetDoctorsBySpeciality(Specialty specialty)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean ChangeSpeciality(Specialty specialty, Model.Users.Doctor doctor)
      {
         // TODO: implement
         return false;
      }
      
      public DoctorGrade GiveGrade(DoctorGrade doctorGrade)
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

        private IService DoctorGrade;
      private Repository.IDoctorRepository _doctorRepository;
   
   }
}