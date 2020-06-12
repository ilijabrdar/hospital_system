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

        public DoctorService(IDoctorRepository doctorRepository, IDoctorGradeService doctorGradeService)
        {
            _doctorRepository = doctorRepository;
            _doctorGradeService = doctorGradeService;
        }

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public void Delete(Doctor entity)
        {
            _doctorRepository.Delete(entity);
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
    }
}