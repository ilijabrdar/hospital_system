/***********************************************************************
 * Module:  ExaminationService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ExaminationService
 ***********************************************************************/

using Model.PatientSecretary;
using Model.Users;
using System;

namespace Controller
{
   public class ExaminationController// : IController
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

//        private Service.IService _service;
   
   }
}