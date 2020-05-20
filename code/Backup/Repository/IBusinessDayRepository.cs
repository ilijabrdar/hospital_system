/***********************************************************************
 * Module:  IBusinessDayRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IBusinessDayRepository
 ***********************************************************************/

using System;

namespace Repository
{
   public interface IBusinessDayRepository : IRepository
   {
      Boolean SetRoomForBusinessDay(BusinessDay businessDay, Room room);
      Model.Users.BusinessDay[] GetBusinessDaysByDate(DateTime date);
   }
}