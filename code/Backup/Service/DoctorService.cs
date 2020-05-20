/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DoctorService
 ***********************************************************************/

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
      
      public Boolean ChangeSpeciality(Speciality speciality, Model.Users.Doctor doctor)
      {
         // TODO: implement
         return null;
      }
      
      public DoctorGrade GiveGrade(DoctorGrade doctorGrade)
      {
         // TODO: implement
         return null;
      }
   
      private IService DoctorGrade;
      private Repository.IDoctorRepository _doctorRepository;
   
   }
}