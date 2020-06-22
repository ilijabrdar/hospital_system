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

namespace Service
{
   public class BusinessDayService : IBusinessDayService
   {
    
        private readonly IBusinessDayRepository _businessDayRepository;
        public ISearchPeriods _searchPeriods { get; set; }
        public static double durationOfExamination = 20;

        public BusinessDayService(IBusinessDayRepository businessDayRepository)
        {
            _businessDayRepository = businessDayRepository;
        }

        public void Delete(BusinessDay entity)
        {
            _businessDayRepository.Delete(entity);
        }

        public bool DeletePreviousBusinessDay()
        {
            throw new NotImplementedException();
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


        public List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO)
        {
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

            throw new NotImplementedException();
        }

        public bool MarkAsOccupied(Period period, BusinessDay businessDay)
        {
            
            throw new NotImplementedException();
        }


        public BusinessDay Save(BusinessDay entity)
        {
            return _businessDayRepository.Save(entity);
        }

        public bool SetRoomForBusinessDay(BusinessDay businessDay, Room room)
        {
            throw new NotImplementedException();
        }

    }
}