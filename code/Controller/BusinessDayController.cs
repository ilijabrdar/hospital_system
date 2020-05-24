/***********************************************************************
 * Module:  BusinessDayService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.BusinessDayService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.Director;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class BusinessDayController : IBusinessDayController
    {

        private readonly IBusinessDayService _businessDayService;

        public BusinessDayController(IBusinessDayService _service)
        {
            _businessDayService = _service;
        }
        
        public void Delete(BusinessDay entity)
        {
            throw new NotImplementedException();
        }

        public bool DeletePreviousBusinessDay()
        {
            throw new NotImplementedException();
        }

        public void Edit(BusinessDay entity)
        {
            throw new NotImplementedException();
        }

        public List<Period> GenerateAvailablePeriods(BusinessDay bussinesDay)
        {
            return _businessDayService.GenerateAvailablePeriods(bussinesDay);
        }

        public BusinessDay Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusinessDay> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<BusinessDay> GetBusinessDaysByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public bool MarkAsOccupied(Period period, BusinessDay businessDay)
        {
            throw new NotImplementedException();
        }

        public List<BusinessDay> PeriodRecommendationByDate(Period period)
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