using bolnica.Repository;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace bolnica.Repository
{
   public interface IExaminationUpcomingRepository : IRepository<Examination, long>, IEagerRepository<Examination, long>
   {
      List<Examination> GetUpcomingExaminationsByUser(User user);
      Examination StartUpcomingExamination(Examination examination);
   }
}