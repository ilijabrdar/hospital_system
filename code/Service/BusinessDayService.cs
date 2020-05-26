/***********************************************************************
 * Module:  BusinessDayService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.BusinessDayService
 ***********************************************************************/

using bolnica.Repository;
using bolnica.Service;
using Model.Director;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
            if (thatDay.ScheduledPeriods.Count == 0) { return retVal; }
            foreach (Period i in thatDay.ScheduledPeriods)
                retVal.Remove(i);
            return retVal;
        }

        private BusinessDay getExactDay(BusinessDay businessDay)
        {
            foreach (BusinessDay day in _businessDayRepository.GetAllEager())
            {
                if (day.doctor.Equals(businessDay.doctor) && day.Shift.EndDate.Date.Equals(businessDay.Shift.EndDate.Date))
                   return day;
            }
            return null;
        }


        public List<Examination> PeriodRecommendationByDate(DateTime date)
        {
            List<BusinessDay> businessDays = _businessDayRepository.GetBusinessDaysByDate(date);

            throw new NotImplementedException();
        }

        public BusinessDay Get(long id)
        {
            return _businessDayRepository.GetEager(id);
        }

        public IEnumerable<BusinessDay> GetAll()
        {
            return _businessDayRepository.GetAllEager().ToList();
        }

        public List<BusinessDay> GetBusinessDaysByDoctor(Doctor doctor)
        {

            throw new NotImplementedException();
        }

        public bool MarkAsOccupied(Period period, BusinessDay businessDay)
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