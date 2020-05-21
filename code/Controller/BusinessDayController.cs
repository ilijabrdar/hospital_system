/***********************************************************************
 * Module:  BusinessDayService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.BusinessDayService
 ***********************************************************************/

using Model.Director;
using Model.PatientSecretary;
using Model.Users;
using System;

namespace Controller
{
   public class BusinessDayController
   {
      public Boolean DeletePreviousBusinessDay()
      {
         // TODO: implement
         return false;
      }
      
      public Boolean SetRoomForBusinessDay(BusinessDay businessDay, Room room)
      {
         // TODO: implement
         return false;
      }
      
      public Model.PatientSecretary.Period[] GenerateAvailablePeriods(Model.Users.BusinessDay bussinesDay)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean MarkAsOccupied(Period period, Model.Users.BusinessDay businessDay)
      {
         // TODO: implement
         return false;
      }
      
      public Model.Users.BusinessDay[] PeriodRecommendationByDate(Model.PatientSecretary.Period period)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Users.BusinessDay[] GetBusinessDaysByDoctor(Model.Users.Doctor doctor)
      {
         // TODO: implement
         return null;
      }

        public object Save()
        {
            throw new NotImplementedException();
        }

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

        //private Service.IService _service;
   
   }
}