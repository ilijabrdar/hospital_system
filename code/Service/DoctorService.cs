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

   
        public void Delete(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public Doctor Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAll()
        {
            throw new NotImplementedException();
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