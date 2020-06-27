using bolnica.Repository;
using bolnica.Service;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;

namespace Service
{
    public class DiagnosisService : IDiagnosisService
    {

        private IDiagnosisRepository _diagnosisRepository;

        public DiagnosisService(IDiagnosisRepository repository)
        {
            _diagnosisRepository = repository;
        }

        public Diagnosis Get(long id)
        {
            return _diagnosisRepository.Get(id);
        }

        public IEnumerable<Diagnosis> GetAll()
        {
            return _diagnosisRepository.GetAll();
        }

    }
}