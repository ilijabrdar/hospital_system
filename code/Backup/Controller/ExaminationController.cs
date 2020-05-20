/***********************************************************************
 * Module:  ExaminationService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ExaminationService
 ***********************************************************************/

using System;

namespace Controller
{
   public class ExaminationController : IController
   {
      public Examination StartScheduledExamination(Examination examination)
      {
         // TODO: implement
         return null;
      }
      
      public Examination FinishExamination(Examination examination)
      {
         // TODO: implement
         return null;
      }
      
      public Examination[] GetScheduledUserExaminations(User user)
      {
         // TODO: implement
         return null;
      }
      
      public Examination[] GetExaminationsByUser(User user)
      {
         // TODO: implement
         return null;
      }
   
      private Service.IService _service;
   
   }
}