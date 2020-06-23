using bolnica.Repository;
using bolnica.Service;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;

namespace Service
{
    public class TherapyService : ITherapyService
    {
        private readonly ITherapyRepository _therapyRepository;

        public TherapyService(ITherapyRepository repository)
        {
            _therapyRepository = repository;
        }

        public Therapy AssignCurrentTherapy(PatientFile patientFile)
        {
            throw new NotImplementedException();
        }

        public void Delete(Therapy entity)
        {
            _therapyRepository.Delete(entity);
        }

        public void Edit(Therapy entity)
        {
            _therapyRepository.Edit(entity);
        }

        public Therapy Get(long id)
        {
            return _therapyRepository.Get(id);
        }

        public IEnumerable<Therapy> GetAll()
        {
            return _therapyRepository.GetAll();
        }

        public Therapy Save(Therapy entity)
        {
            return _therapyRepository.Save(entity);
        }
    }
}