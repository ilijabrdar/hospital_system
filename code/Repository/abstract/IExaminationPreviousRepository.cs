using bolnica.Repository;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Repository
{
   public interface IExaminationPreviousRepository : IRepository<Examination,long>, IEagerRepository<Examination, long>
    { 
      List<Examination> GetExaminationsByUser(User user);
   }
}