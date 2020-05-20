/***********************************************************************
 * Module:  BusinessDayService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.BusinessDayService
 ***********************************************************************/

using System;

namespace Controller
{
   public class BusinessDayController : IController
   {
      public Boolean DeletePreviousBusinessDay()
      {
         // TODO: implement
         return null;
      }
      
      public Boolean SetRoomForBusinessDay(BusinessDay businessDay, Room room)
      {
         // TODO: implement
         return null;
      }
      
      public Model.PatientSecretary.Period[] GenerateAvailablePeriods(Model.Users.BusinessDay bussinesDay)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean MarkAsOccupied(Period period, Model.Users.BusinessDay businessDay)
      {
         // TODO: implement
         return null;
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
   
      private Service.IService _service;
   
   }
}