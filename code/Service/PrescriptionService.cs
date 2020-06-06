/***********************************************************************
 * Module:  PrescriptionService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.PrescriptionService
 ***********************************************************************/

using bolnica.Repository;
using bolnica.Service;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;

namespace Service
{
    public class PrescriptionService : IPrescriptionService
    {
        private IPrescriptionRepository _repository;

        public PrescriptionService(IPrescriptionRepository repository)
        {
            _repository = repository;
        }

        public void Delete(Prescription entity)
        {
            _repository.Delete(entity);
        }

        public void Edit(Prescription entity)
        {
            _repository.Edit(entity);
        }

        public Prescription Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Prescription> GetAll()
        {
            return _repository.GetAll();
        }

        public Prescription Save(Prescription entity)
        {
            return _repository.Save(entity);
        }
    }
}