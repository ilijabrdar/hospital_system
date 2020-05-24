/***********************************************************************
 * Module:  BusinessDayService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.BusinessDayService
 ***********************************************************************/

using bolnica.Service;
using Model.Director;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class BusinessDayService : IBusinessDayService
   {
    
        private IBusinessDayRepository _businessDayRepository;
        public static double durationOfExamination = 20;

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

        public List<Period> GenerateAvailablePeriods(BusinessDay businessDay)
        {
            BusinessDay thatDay = getExactDay(businessDay);
            if (thatDay.Equals(null))
            {
                return null;
            }
            List<Period> retVal = new List<Period>();
            DateTime start = thatDay.Shift.StartDate;
            DateTime end = start.AddMinutes(durationOfExamination);
            while(end < thatDay.Shift.EndDate)
            {
                retVal.Add(new Period(start, end));
                start.AddMinutes(durationOfExamination);
                end.AddMinutes(durationOfExamination);
            }
            return retVal;
        }

        private BusinessDay getExactDay(BusinessDay businessDay)
        {
            foreach (BusinessDay day in _businessDayRepository.GetAll())
            {
                if (day.doctor.Equals(businessDay.doctor) && day.Shift.EndDate.Date.Equals(businessDay.Shift.EndDate.Date))
                   return day;
            }
            return null;
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