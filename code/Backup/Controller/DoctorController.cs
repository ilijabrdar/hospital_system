/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DoctorService
 ***********************************************************************/

using System;

namespace Controller
{
   public class DoctorController : IController
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
   
      private Service.IService iService;
   
   }
}