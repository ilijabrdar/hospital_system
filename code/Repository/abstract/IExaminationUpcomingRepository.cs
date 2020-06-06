/***********************************************************************
 * Module:  IExaminationUpcomingRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IExaminationUpcomingRepository
 ***********************************************************************/

using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Repository
{
   public interface IExaminationUpcomingRepository : IRepository<Examination, long>
   {
      List<Examination> GetScheduledUserExaminations(User user);
      Examination StartUpcomingExamination(Examination examination);
   }
}