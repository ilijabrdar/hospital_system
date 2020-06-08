using bolnica.Model.Dto;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
   public class NoPrioritySearch : ISearchPeriods
    {
        public NoPrioritySearch() { }

        public List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO, List<BusinessDay> businessDayCollection)
        {
            List<BusinessDay> IterationDays = DaysForExactPeriod(businessDayDTO.Period, businessDayDTO.Doctor.BusinessDay);
            foreach (BusinessDay day in IterationDays)
            {
                List<ExaminationDTO> retVal = CreateExaminationDTO(day);
                if (retVal != null)
                {
                    return retVal;
                }
            }
            return null;
        }

        private List<ExaminationDTO> CreateExaminationDTO(BusinessDay businessDay)
        {
            List<ExaminationDTO> retVal = new List<ExaminationDTO>();
            DateTime Start = businessDay.Shift.StartDate;
            DateTime End = Start.AddMinutes(BusinessDayService.durationOfExamination);
            while (End <= businessDay.Shift.EndDate)
            {
                if (!businessDay.ScheduledPeriods.Any(item => item == new Period(Start, End)))
                {
                    ExaminationDTO examinationDTO = new ExaminationDTO
                    {
                        room = businessDay.room,
                        period = new Period(Start, End),
                        doctor = businessDay.doctor
                    };
                    retVal.Add(examinationDTO);
                }

            }
            return null;
        }

        private List<BusinessDay> DaysForExactPeriod(Period period, List<BusinessDay> businessDaysCollection)
        {
            List<BusinessDay> businessDays = new List<BusinessDay>();
            foreach (BusinessDay day in businessDaysCollection)
            {
                if (day.Shift.StartDate.Date >= period.StartDate.Date && day.Shift.EndDate.Date <= period.EndDate.Date)
                {
                    businessDays.Add(day);
                    return businessDays;
                }
            }

            return null;
        }
    }
}
