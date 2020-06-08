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

        //private IService DoctorGrade;
      private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
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

        public Doctor GetDoctorByUsername(string username)
        {
            return _doctorRepository.GetDoctorByUsername(username);
        }


        public Doctor Save(Doctor entity)
        {
            if (_doctorRepository.GetDoctorByUsername(entity.Username) != null)
                {
                    return null;
                }
            return _doctorRepository.Save(entity);
        }
    }
}