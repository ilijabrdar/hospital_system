using bolnica.Repository;
using bolnica.Service;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;

namespace Service
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;

        public PrescriptionService(IPrescriptionRepository repository)
        {
            _prescriptionRepository = repository;
        }

        public void Delete(Prescription entity)
        {
            _prescriptionRepository.Delete(entity);
        }

        public void Edit(Prescription entity)
        {
            _prescriptionRepository.Edit(entity);
        }

        public Prescription Get(long id)
        {
            return _prescriptionRepository.Get(id);
        }

        public IEnumerable<Prescription> GetAll()
        {
            return _prescriptionRepository.GetAll();
        }

        public Prescription Save(Prescription entity)
        {
            return _prescriptionRepository.Save(entity);
        }
    }
}