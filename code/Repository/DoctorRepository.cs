/***********************************************************************
 * Module:  DoctorService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DoctorService
 ***********************************************************************/

using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;
using bolnica.Repository;
using System.Linq;
using Service;

namespace Repository
{
   public class DoctorRepository : CSVRepository<Doctor, long>, IDoctorRepository, IEagerRepository<Doctor,long>
   {
        private readonly IArticleRepository articleRepo;
        private readonly IEagerRepository<BusinessDay,long> businessDayRepo;
        private readonly ISpecialityRepository specialityRepo;
        public DoctorRepository(ICSVStream<Doctor> stream, ISequencer<long> sequencer,
            IArticleRepository article, IEagerRepository<BusinessDay,long> businessDay, ISpecialityRepository speciality) 
            : base(stream, sequencer)
        {
            articleRepo = article;
            specialityRepo = speciality;
            businessDayRepo = businessDay;
        }

        public IEnumerable<Doctor> GetAllEager()
        {
            List<Doctor> doctors = new List<Doctor>();
            foreach(Doctor doctor in GetAll().ToList())
            {
                doctors.Add(GetEager(doctor.GetId()));
            }

            return doctors;
            
        }
        public Doctor GetEager(long id)
        {
            Doctor doctor = Get(id);
            List<Article> articles = new List<Article>();
            foreach(Article art in doctor.articles)
            {
                articles.Add(articleRepo.Get(art.GetId()));
            }
            doctor.articles = articles;
            List<BusinessDay> businessDays = new List<BusinessDay>();
            foreach(BusinessDay day in doctor.businessDay)
            {
                businessDays.Add(businessDayRepo.GetEager(day.GetId()));
            }
            doctor.businessDay = businessDays;
            doctor.specialty = specialityRepo.Get(doctor.specialty.GetId());
            // TODO : uraditi za GradeDoctor i repo i interfejs i cuvanje Converter i ovde ga onda staviti!
            throw new NotImplementedException();
        }

        public Doctor GetDoctorByUsername(string username)
        {
            IEnumerable<Doctor> entities = this.GetAll();
            foreach (Doctor entity in entities)
            {
                if (entity.Username.Equals(username))
                    return entity;
            }
            return null;
        }

        public List<Doctor> GetDoctorsBySpeciality(Speciality specialty)
        {
            List<Doctor> doctors = this.GetAll().ToList();
            List<Doctor> retVal = new List<Doctor>();
            foreach(Doctor doct in doctors)
            {
                if (doct.specialty.Equals(specialty))
                    retVal.Add(doct);
            }
            return retVal;
        }


    }
}