

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
      Boolean SetRoomForBusinessDay(BusinessDay businessDay, Room room);
      List<BusinessDay> GetBusinessDaysByDate(DateTime date);
   }
}