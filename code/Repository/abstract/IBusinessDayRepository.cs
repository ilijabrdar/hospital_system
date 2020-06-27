

using bolnica.Repository;
using Model.Director;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IBusinessDayRepository : IRepository<BusinessDay, long>, IEagerRepository<BusinessDay, long>
    {

      List<BusinessDay> GetBusinessDaysByDate(DateTime date);
   }
}