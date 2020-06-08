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
      private ISpecialityRepository _repository;

        public SpecialityService(ISpecialityRepository repository)
        {
            _repository = repository;
        }

        public void Delete(Speciality entity)
        {
            _repository.Delete(entity);
        }

        public void Edit(Speciality entity)
        {
            _repository.Edit(entity);
        }

        public Speciality Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Speciality> GetAll()
        {
            return _repository.GetAll();
        }

        public Speciality Save(Speciality entity)
        {
            return _repository.Save(entity);
        }
    }
}