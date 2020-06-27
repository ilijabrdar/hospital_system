

using bolnica.Controller;
using bolnica.Model.Dto;
using bolnica.Service;
using Model.Director;
using Model.Dto;
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
            _businessDayService.Delete(entity);
        }

        public void Edit(BusinessDay entity)
        {
            _businessDayService.Edit(entity);
        }

        public BusinessDay Get(long id)
        {
            return _businessDayService.Get(id);  
        }

        public IEnumerable<BusinessDay> GetAll()
        {
            return _businessDayService.GetAll();
        }

        public List<BusinessDay> GetBusinessDaysByDoctor(Doctor doctor)
        {
            return _businessDayService.GetBusinessDaysByDoctor(doctor);
        }

        public void MarkAsOccupied(List<Period> period, BusinessDay businessDay)
        {
            _businessDayService.MarkAsOccupied(period, businessDay);
        }

        public BusinessDay Save(BusinessDay entity)
        {
            return _businessDayService.Save(entity);
        }

        public List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO)
        {
            return _businessDayService.Search(businessDayDTO);
        }

        public void FreePeriod(BusinessDay businessDay, List<DateTime> period)
        {
            _businessDayService.FreePeriod(businessDay, period);
        }

        public BusinessDay GetExactDay(Doctor doctor, DateTime date)
        {
            return _businessDayService.GetExactDay(doctor, date);
        }

        public Boolean isExaminationPossible(Examination examination)
        {
            return _businessDayService.isExaminationPossible(examination);
        }

        public bool ChangeDoctorShift(BusinessDay  newShift)
        {
            return _businessDayService.ChangeDoctorShift(newShift);
        }
    }
}