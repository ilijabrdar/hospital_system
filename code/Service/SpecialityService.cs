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
      private readonly ISpecialityRepository _repository;

        public SpecialityService(ISpecialityRepository repository)
        {
            _repository = repository;
        }


        public Speciality Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Speciality> GetAll()
        {
            return _repository.GetAll();
        }

    }
}