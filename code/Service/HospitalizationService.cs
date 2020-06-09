/***********************************************************************
 * Module:  HospitalizationService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.HospitalizationService
 ***********************************************************************/

using bolnica.Service;
using Model.Doctor;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class HospitalizationService : IHospitalizationService
   {
      private IHospitalizationRepository _repository;

        public HospitalizationService(IHospitalizationRepository repository)
        {
            _repository = repository;
        }

        public void Delete(Hospitalization entity)
        {
            _repository.Delete(entity);
        }

        public void Edit(Hospitalization entity)
        {
            _repository.Edit(entity);
        }

        public Hospitalization Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Hospitalization> GetAll()
        {
            return _repository.GetAll();
        }

        public Hospitalization Save(Hospitalization entity)
        {
            return _repository.Save(entity);
        }
    }
}