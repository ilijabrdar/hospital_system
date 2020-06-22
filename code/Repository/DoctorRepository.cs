using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;
using bolnica.Repository;
using System.Linq;
using Service;

namespace Repository
{
    public class DoctorRepository : CSVRepository<Doctor, long>, IDoctorRepository
    {
        private readonly IEagerRepository<BusinessDay, long> businessDayRepo;
        private readonly ISpecialityRepository specialityRepo;
        private readonly IDoctorGradeRepository doctorGradeRepository;
        public DoctorRepository(ICSVStream<Doctor> stream, ISequencer<long> sequencer, IEagerRepository<BusinessDay, long> businessDay, ISpecialityRepository speciality,
            IDoctorGradeRepository doctorGrade)
            : base(stream, sequencer)
        {
            specialityRepo = speciality;
            businessDayRepo = businessDay;
            doctorGradeRepository = doctorGrade;
        }

        public IEnumerable<Doctor> GetAllEager()
        {
            List<Doctor> doctors = new List<Doctor>();
            foreach (Doctor doctor in GetAll().ToList())
            {
                doctors.Add(GetEager(doctor.GetId()));
            }

            return doctors;

        }
        public Doctor GetEager(long id)
        {
            Doctor doctor = Get(id);

            List<BusinessDay> businessDays = new List<BusinessDay>();
            if (doctor.BusinessDay != null)
            {
                foreach (BusinessDay day in doctor.BusinessDay)
                {
                    businessDays.Add(businessDayRepo.GetEager(day.GetId()));
                }
            }
            doctor.BusinessDay = businessDays;
            doctor.Specialty = specialityRepo.Get(doctor.Specialty.GetId());
            doctor.DoctorGrade = doctorGradeRepository.Get(doctor.DoctorGrade.GetId());

            return doctor;
        }

        public User GetUserByUsername(string username)
        {
            IEnumerable<Doctor> entities = this.GetAllEager().ToList();
            foreach (Doctor entity in entities)
            {
                if (entity.Username.Equals(username))
                    return entity;
            }
            return null;
        }

        public List<Doctor> GetDoctorsBySpeciality(Speciality specialty)
        {
            List<Doctor> doctors = this.GetAllEager().ToList();
            List<Doctor> retVal = new List<Doctor>();
            foreach (Doctor doct in doctors)
            {
                if (doct.Specialty.Name.Equals(specialty.Name))
                    retVal.Add(doct);
            }
            return retVal;
        }


    }
}
