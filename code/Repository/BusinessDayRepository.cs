/***********************************************************************
 * Module:  BusinessDayService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.BusinessDayService
 ***********************************************************************/

using Model.Director;
using Model.Users;
using System;

namespace Repository
{
   public class BusinessDayRepository : IBusinessDayRepository
   {
      private String FilePath;

        public object Delete()
        {
            throw new NotImplementedException();
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }

        public BusinessDay[] GetBusinessDaysByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public object Save()
        {
            throw new NotImplementedException();
        }

        public bool SetRoomForBusinessDay(BusinessDay businessDay, Room room)
        {
            throw new NotImplementedException();
        }
    }
}