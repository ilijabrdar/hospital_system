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
        private readonly IEagerRepository<BusinessDay, long> _businessDayRepo;
        private readonly ISpecialityRepository _specialityRepo;
        private readonly IDoctorGradeRepository _doctorGradeRepository;
        private readonly IEagerRepository<Address, long> _addressRepository;
        private readonly IEagerRepository<Town, long> _townRepository;
        private readonly IEagerRepository<State, long> _stateRepository;

        public DoctorRepository(ICSVStream<Doctor> stream, ISequencer<long> sequencer, IEagerRepository<BusinessDay, long> businessDay, ISpecialityRepository speciality,
            IDoctorGradeRepository doctorGrade, IEagerRepository<Address, long> addressRepository,
            IEagerRepository<Town, long> townRepository, IEagerRepository<State, long> stateRepository)
            : base(stream, sequencer)
        {
            _specialityRepo = speciality;
            _businessDayRepo = businessDay;
            _doctorGradeRepository = doctorGrade;
            _addressRepository = addressRepository;
            _townRepository = townRepository;
            _stateRepository = stateRepository;
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
                    businessDays.Add(_businessDayRepo.GetEager(day.GetId()));
                }
            }
            doctor.BusinessDay = businessDays;

            doctor.Specialty = _specialityRepo.Get(doctor.Specialty.GetId());
            doctor.Address = _addressRepository.GetEager(doctor.Address.GetId());
            doctor.Address.Town = _townRepository.GetEager(doctor.Address.Town.GetId());
            doctor.Address.Town.State = _stateRepository.GetEager(doctor.Address.Town.State.GetId());
            doctor.DoctorGrade = _doctorGradeRepository.Get(doctor.DoctorGrade.GetId());

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
