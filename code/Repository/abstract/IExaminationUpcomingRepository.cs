using bolnica.Repository;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Repository
{
   public interface IExaminationUpcomingRepository : IRepository<Examination, long>, IEagerRepository<Examination, long>
    {
      List<Examination> GetScheduledUserExaminations(User user);
      Examination StartUpcomingExamination(Examination examination);
   }
}