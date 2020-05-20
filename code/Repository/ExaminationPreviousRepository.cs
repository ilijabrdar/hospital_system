/***********************************************************************
 * Module:  ExaminationService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ExaminationService
 ***********************************************************************/

using Model.PatientSecretary;
using Model.Users;
using System;

namespace Repository
{
   public class ExaminationPreviousRepository : IExaminationPreviousRepository
   {
      private String FilePath;

        public bool DeleteExamination(Examination examination)
        {
            throw new NotImplementedException();
        }

        public Examination[] GetExaminations()
        {
            throw new NotImplementedException();
        }

        public Examination[] GetExaminationsByUser(User user)
        {
            throw new NotImplementedException();
        }

        public Examination SaveExamination(Examination examination)
        {
            throw new NotImplementedException();
        }
    }
}