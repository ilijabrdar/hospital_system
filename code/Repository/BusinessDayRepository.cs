/***********************************************************************
 * Module:  BusinessDayService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.BusinessDayService
 ***********************************************************************/

using Model.Director;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class BusinessDayRepository : IBusinessDayRepository
   {
      private String FilePath;

        public void Delete(BusinessDay entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(BusinessDay entity)
        {
            throw new NotImplementedException();
        }

        public BusinessDay Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessDay> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<BusinessDay> GetBusinessDaysByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public BusinessDay Save(BusinessDay entity)
        {
            throw new NotImplementedException();
        }

        public bool SetRoomForBusinessDay(BusinessDay businessDay, Room room)
        {
            throw new NotImplementedException();
        }
    }
}