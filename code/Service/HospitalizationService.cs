using bolnica.Service;
using Model.Doctor;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class HospitalizationService : IHospitalizationService
   {
      private IHospitalizationRepository _hospitalizationRepository;

        public HospitalizationService(IHospitalizationRepository repository)
        {
            _hospitalizationRepository = repository;
        }

        public void Delete(Hospitalization entity)
        {
            _hospitalizationRepository.Delete(entity);
        }

        public void Edit(Hospitalization entity)
        {
            _hospitalizationRepository.Edit(entity);
        }

        public Hospitalization Get(long id)
        {
            return _hospitalizationRepository.Get(id);
        }

        public IEnumerable<Hospitalization> GetAll()
        {
            return _hospitalizationRepository.GetAll();
        }

        public Hospitalization Save(Hospitalization entity)
        {
            return _hospitalizationRepository.Save(entity);
        }
    }
}