using bolnica.Model.Dto;
using bolnica.Repository;
using bolnica.Service;
using Model.Director;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Configuration;
using System.Web.Configuration;

namespace Service
{
    public class BusinessDayService : IBusinessDayService
    {

        private readonly IBusinessDayRepository _businessDayRepository;
        public ISearchPeriods _searchPeriods { get; set; }

        [Obsolete]
        public static double durationOfExamination = Double.Parse(ConfigurationSettings.AppSettings["examinationDuration"]);

        public IDoctorService doctorService;

        public IExaminationService examinationService { get; set; }

        public BusinessDayService(IBusinessDayRepository businessDayRepository, IDoctorService doctorService)
        {
            _businessDayRepository = businessDayRepository;
            this.doctorService = doctorService;
        }

        public void Delete(BusinessDay entity)
        {
            doctorService.DeleteBusinessDayFromDoctor(entity);
            _businessDayRepository.Delete(entity);
        }

        public void Edit(BusinessDay entity)
        {
                _businessDayRepository.Edit(entity);
        }

        public BusinessDay GetExactDay(Doctor doctor, DateTime date)
        {
           
            foreach (BusinessDay day in _businessDayRepository.GetAllEager())
            {
                if (day.doctor.Id == doctor.Id && day.Shift.EndDate.Date.Equals(date.Date))
                    return day;
            }
            return null;
        }

        [Obsolete]
        public List<ExaminationDTO> OperationSearch(BusinessDayDTO businessDayDTO, double durationOfOperation)
        {
            List<ExaminationDTO> retVal = new List<ExaminationDTO>();
            _searchPeriods = new NoPrioritySearch();
            List<ExaminationDTO> timeSlots = Search(businessDayDTO);
            
            if (timeSlots == null)
                return null;

            double MinutesFree = 0;
            foreach(ExaminationDTO examinationDTO in timeSlots)
            {
                if (retVal.Count == 0)
                {
                    retVal.Add(examinationDTO);
                    MinutesFree = MinutesFree + durationOfExamination;
                }
                else
                {
                    if (retVal.SingleOrDefault(any => any.Period.StartDate.AddMinutes(durationOfExamination) == examinationDTO.Period.StartDate) != null)
                    {
                        retVal.Add(examinationDTO);
                        MinutesFree += durationOfExamination;
                    }
                    else
                    {
                        retVal.Clear();
                        retVal.Add(examinationDTO);
                        MinutesFree = durationOfExamination;
                    }
                }
                if(durationOfOperation == MinutesFree)
                    break;
           
            }

            return retVal;

        }

        [Obsolete]
        public List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO)
        {
            TimeSpan difference = businessDayDTO.Period.StartDate - DateTime.Now;
            if(difference.Days <= Double.Parse(ConfigurationSettings.AppSettings["scheduleRestriction"])){
                if(businessDayDTO.PatientScheduling)
                {
                    if(_searchPeriods.GetType() != typeof(NoPrioritySearch))
                        businessDayDTO.Period.StartDate = businessDayDTO.Period.StartDate.AddDays(Double.Parse(ConfigurationSettings.AppSettings["scheduleRestriction"]));
                    else
                        return null;
                }
            }
            businessDayDTO.Doctor = doctorService.Get(businessDayDTO.Doctor.GetId());
            List<BusinessDay> businessDayCollection = _businessDayRepository.GetAllEager().ToList();
            return _searchPeriods.Search(businessDayDTO, businessDayCollection);
        }


        public BusinessDay Get(long id)
        {
            return _businessDayRepository.GetEager(id);
        }

        public IEnumerable<BusinessDay> GetAll()
        {
            return _businessDayRepository.GetAllEager();
        }

        public List<BusinessDay> GetBusinessDaysByDoctor(Doctor doctor)
        {
            List<BusinessDay> ret = new List<BusinessDay>();

            foreach (BusinessDay businessDay in GetAll())
                if (businessDay.doctor.Id == doctor.Id)
                    ret.Add(businessDay);

            return ret;
        }

        public void MarkAsOccupied(List<Period> period, BusinessDay businessDay)
        {
            businessDay.ScheduledPeriods.AddRange(period);
            _businessDayRepository.Edit(businessDay);
        }


        public BusinessDay Save(BusinessDay entity)
        {
            if (validateDates(entity))
                return _businessDayRepository.Save(entity);
            else
                return null;
        }

        private bool validateDates(BusinessDay entity)
        {
            foreach (BusinessDay businessDay in GetBusinessDaysByDoctor(entity.doctor)) //15/07 - 25/-7
                if (businessDay.Shift.StartDate.Date == entity.Shift.StartDate.Date)
                    return false;

            return true;
        }



        public void DeleteBusinessDayByRoom(Room room)
        {
            foreach (BusinessDay businessDay in GetAll())
            {
                if (businessDay.room.Id == room.Id)
                {
                    
                    Delete(businessDay);
                }
            }
        }

        public void FreePeriod(BusinessDay businessDay, List<DateTime> period)
        {
            int index = 0;
            for(int i = 0; i < businessDay.ScheduledPeriods.Count; i++)
            {
                if(businessDay.ScheduledPeriods[i].StartDate == period[index])
                {
                    businessDay.ScheduledPeriods.RemoveAt(i--);
                    if (index == period.Count - 1)
                        break;
                    index++;
                }
            }

            Edit(businessDay);
        }

        [Obsolete]
        public Boolean ChangeDoctorShift(BusinessDay newShift)
        {
            TimeSpan shiftDuration = new TimeSpan();
            shiftDuration = newShift.Shift.EndDate - newShift.Shift.StartDate;  

            double periodTotalMinutes = 0;
            if (newShift.ScheduledPeriods == null)
                return true;

            foreach (Period period in newShift.ScheduledPeriods)
                periodTotalMinutes += durationOfExamination;
            

            if (shiftDuration.TotalMinutes < periodTotalMinutes)
                return false;

            foreach (Period period in newShift.ScheduledPeriods)
                if (!periodCorrespondsToNewShift(newShift.Shift, period))
                    return false;
                
            return true;
        }

        private bool periodCorrespondsToNewShift(Period shift, Period period)
        {
            if (DateTime.Compare(shift.StartDate, period.StartDate)<= 0 && DateTime.Compare(shift.EndDate, period.EndDate) >= 0)
                return true;

            return false;
        }

        [Obsolete]
        public Boolean isExaminationPossible(Examination examination)
        {
            _searchPeriods = new NoPrioritySearch();
            List<ExaminationDTO> examinations = Search(new BusinessDayDTO(examination.Doctor, examination.Period));
            foreach (ExaminationDTO exam in examinations)
            {
                if (exam.Period.StartDate == examination.Period.StartDate)
                    return true;
            }
            return false;
        }

    }
}