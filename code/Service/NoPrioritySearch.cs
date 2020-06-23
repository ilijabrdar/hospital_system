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
            if (IterationDays != null)
            {
                foreach (BusinessDay day in IterationDays)
                {
                    List<ExaminationDTO> retVal = CreateExaminationDTO(day);
                    if (retVal != null)
                    {
                        return retVal;
                    }
                }
            }
            return null;
        }

        public List<ExaminationDTO> CreateExaminationDTO(BusinessDay businessDay)
        {
            List<ExaminationDTO> retVal = new List<ExaminationDTO>();
            DateTime Start = businessDay.Shift.StartDate;
            DateTime End = Start.AddMinutes(BusinessDayService.durationOfExamination);
            while (End <= businessDay.Shift.EndDate)
            {


                //if (!businessDay.ScheduledPeriods.Any(item => item == new Period(Start, End)))
                if (businessDay.ScheduledPeriods.SingleOrDefault(x => x.StartDate == Start) == null)
                {
                    ExaminationDTO examinationDTO = new ExaminationDTO
                    {
                        Room = businessDay.room,
                        Period = new Period(Start, End),
                        Doctor = businessDay.doctor
                    };
                    retVal.Add(examinationDTO);
                }
                End = End.AddMinutes(BusinessDayService.durationOfExamination);
                Start = Start.AddMinutes(BusinessDayService.durationOfExamination);

            }
            return retVal;
        }

        public List<BusinessDay> DaysForExactPeriod(Period period, List<BusinessDay> businessDaysCollection)
        {
            List<BusinessDay> businessDays = new List<BusinessDay>();
            if (businessDaysCollection != null)
            {
                foreach (BusinessDay day in businessDaysCollection)
                {
                    if (day.Shift.StartDate.Date == period.StartDate.Date)
                    {
                        businessDays.Add(day);
                        return businessDays;
                    }
                }
            }
            return null;
        }
    }
}
