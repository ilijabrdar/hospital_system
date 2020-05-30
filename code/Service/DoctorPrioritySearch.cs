using bolnica.Model.Dto;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

namespace bolnica.Service
{
    public class DoctorPrioritySearch : ISearchPeriods
    {
        public DoctorPrioritySearch() { }

        public List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO, List<BusinessDay> businessDayCollection)
        {
            List<ExaminationDTO> examinationDTO = new List<ExaminationDTO>();
            List<BusinessDay> IterationDays = DaysForExactPeriod(businessDayDTO.Period, businessDayDTO.Doctor.businessDay);
            ExaminationDTO examination = new ExaminationDTO();
            foreach (BusinessDay day in IterationDays)
            {
                examination = CreateExaminationDTO(day);
                if(examination != null)
                {
                    examination.doctor = businessDayDTO.Doctor;
                    examinationDTO.Add(examination);
                    return examinationDTO;
                }
            }

            return AlternativeForPeriod(businessDayDTO.Doctor.businessDay.Except(IterationDays));
        }

        private List<ExaminationDTO> AlternativeForPeriod(IEnumerable<BusinessDay> enumerable)
        {
            List<ExaminationDTO> examinationDTO = new List<ExaminationDTO>();


            return examinationDTO;
        }



        private ExaminationDTO CreateExaminationDTO(BusinessDay businessDay)
        {
            DateTime Start = businessDay.Shift.StartDate;
            DateTime End = Start.AddMinutes(BusinessDayService.durationOfExamination);
            while(End < businessDay.Shift.EndDate)
            {
                if(!businessDay.ScheduledPeriods.Any(item => item == new Period(Start, End)))
                {
                    ExaminationDTO examinationDTO = new ExaminationDTO();
                    examinationDTO.room = businessDay.room;
                    examinationDTO.period = new Period(Start, End);
                    return examinationDTO;
                }
                
            }
            return null;
        }


        private List<BusinessDay> DaysForExactPeriod(Period period, List<BusinessDay> businessDaysCollection)
        {
            List<BusinessDay> businessDays = new List<BusinessDay>();
            foreach(BusinessDay day in businessDaysCollection)
            {
                if(day.Shift.EndDate.Date >= period.EndDate.Date && day.Shift.EndDate.Date <= period.EndDate.Date)
                {
                    businessDays.Add(day);
                }
            }

            return businessDays;
        }
    }
}
