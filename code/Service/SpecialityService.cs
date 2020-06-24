using bolnica.Service;
using Model.Doctor;
using Repository;
using System;
using System.Collections.Generic;
using Speciality = Model.Doctor.Speciality;

namespace Service
{
   public class SpecialityService : ISpecialityService
   {
      private readonly ISpecialityRepository _specialityRepository;

        public SpecialityService(ISpecialityRepository repository)
        {
            _specialityRepository = repository;
        }

        public Speciality Get(long id)
        {
            return _specialityRepository.Get(id);
        }

        public IEnumerable<Speciality> GetAll()
        {
            return _specialityRepository.GetAll();
        }

    }
}