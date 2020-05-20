/***********************************************************************
 * Module:  DoctorGradeService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DoctorGradeService
 ***********************************************************************/

using Model.Users;
using System;
using System.Collections.Generic;

namespace Service
{
   public class DoctorGradeService
   {
      public List<String> GetQuestions()
      {
         // TODO: implement
         return null;
      }
      
      public double GetAverage(Doctor doctor, List<int> grades)
      {
         // TODO: implement
         return 0.0;
      }
   
      private Repository.IDoctorGradeRepository _gradeRepository;
   
   }
}