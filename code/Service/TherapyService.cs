using bolnica.Repository;
using bolnica.Service;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;

namespace Service
{
    public class TherapyService : ITherapyService
    {
        private readonly ITherapyRepository _repository;

        public Therapy AssignCurrentTherapy(PatientFile patientFile)
        {
            throw new NotImplementedException();
        }

        public void Delete(Therapy entity)
        {
            _repository.Delete(entity);
        }

        public void Edit(Therapy entity)
        {
            _repository.Edit(entity);
        }

        public Therapy Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Therapy> GetAll()
        {
            return _repository.GetAll();
        }

        public Therapy Save(Therapy entity)
        {
            return _repository.Save(entity);
        }
    }
}