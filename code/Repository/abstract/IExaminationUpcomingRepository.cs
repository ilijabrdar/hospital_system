/***********************************************************************
 * Module:  IExaminationUpcomingRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IExaminationUpcomingRepository
 ***********************************************************************/

using Model.PatientSecretary;
using Model.Users;
using System;

namespace Repository
{
   public interface IExaminationUpcomingRepository
   {
      Examination SaveExamination(Examination examination);
      Examination EditExamination(Examination newExamination);
      Boolean DeleteExamination(Examination examination);
      Examination[] GetScheduledUserExaminations(User user);
      Examination StartScheduledExamination(Examination examination);
   }
}