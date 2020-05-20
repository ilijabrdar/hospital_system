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
   public class ExaminationUpcomingRepository : IExaminationUpcomingRepository
   {
      private String FilePath;

        public bool DeleteExamination(Examination examination)
        {
            throw new NotImplementedException();
        }

        public Examination EditExamination(Examination newExamination)
        {
            throw new NotImplementedException();
        }

        public Examination[] GetScheduledUserExaminations(User user)
        {
            throw new NotImplementedException();
        }

        public Examination SaveExamination(Examination examination)
        {
            throw new NotImplementedException();
        }

        public Examination StartScheduledExamination(Examination examination)
        {
            throw new NotImplementedException();
        }
    }
}