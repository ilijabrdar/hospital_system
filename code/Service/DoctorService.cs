using bolnica.Service;
using Model.Doctor;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class DoctorService : IDoctorService
   {

        private readonly IDoctorGradeService _doctorGradeService;
      private readonly IDoctorRepository _doctorRepository;
        public IBusinessDayService businessDayService;
        public IArticleService articleService;

        public DoctorService(IDoctorRepository doctorRepository, IDoctorGradeService doctorGradeService, IBusinessDayService businessDayService, IArticleService articleService)
        {
            _doctorRepository = doctorRepository;
            _doctorGradeService = doctorGradeService;
            this.businessDayService = businessDayService;
            this.articleService = articleService;
        }

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public void Delete(Doctor entity)
        {
            DeleteDoctorsBusinessDays(entity);
            articleService.DeleteArticlesByDoctor(entity);
            _doctorRepository.Delete(entity);
        }

        private void DeleteDoctorsBusinessDays(Doctor entity)
        {
            foreach (BusinessDay businessDay in entity.BusinessDay)
                businessDayService.Delete(businessDay);
        }

        public void Edit(Doctor entity)
        {
            _doctorRepository.Edit(entity);
        }

        public Doctor Get(long id)
        {
            return _doctorRepository.GetEager(id);
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAllEager();
        }

        public List<Doctor> GetDoctorsBySpeciality(Speciality specialty)
        {
            return _doctorRepository.GetDoctorsBySpeciality(specialty);
        }

        public User GetUserByUsername(string username)
        {
            return _doctorRepository.GetUserByUsername(username);
        }


        public Doctor Save(Doctor entity)
        {
            if (_doctorRepository.GetUserByUsername(entity.Username) != null)
                {
                    return null;
                }
            return _doctorRepository.Save(entity);
        }

        public void DeleteBusinessDayFromDoctor(BusinessDay businessDay)
        {
            Doctor doctor = Get(businessDay.doctor.Id);
            foreach (BusinessDay business in doctor.BusinessDay)
            {
                if (business.Id == businessDay.Id)
                {
                    doctor.BusinessDay.Remove(business);
                    Edit(doctor);
                    break;
                }
            }
                

        }

        public bool CheckJMBGUnique(string JMBG)
        {
            foreach (Doctor doctor in GetAll())
            {
                if (doctor.Jmbg.Equals(JMBG))
                    return false;
                    
            }

            return true;
        }
    }
}