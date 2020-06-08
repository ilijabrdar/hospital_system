/***********************************************************************
 * Module:  IBusinessDayRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IBusinessDayRepository
 ***********************************************************************/

using bolnica.Repository;
using Model.Director;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IBusinessDayRepository : IRepository<BusinessDay, long>
   {
      Boolean SetRoomForBusinessDay(BusinessDay businessDay, Room room);
      List<BusinessDay> GetBusinessDaysByDate(DateTime date);
   }
}