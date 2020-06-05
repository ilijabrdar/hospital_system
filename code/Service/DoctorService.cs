

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

        public DoctorService(IDoctorRepository repo)
        {
            _doctorRepository = repo;
        }

        public bool ChangeSpeciality(Model.Doctor.Speciality specialty, Doctor doctor)
        {
            throw new NotImplementedException();
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

        public List<Doctor> GetDoctorsBySpeciality(Model.Doctor.Speciality specialty)
        {
            return _doctorRepository.GetDoctorsBySpeciality(specialty);
        }

        public DoctorGrade GiveGrade(DoctorGrade doctorGrade)
        {
            throw new NotImplementedException();
        }

        public Doctor Save(Doctor entity)
        {
            if (_doctorRepository.GetDoctorByUsername(entity.Username).Equals(null))
                {
                    return null;
                }
            return _doctorRepository.Save(entity);
        }
    }
}