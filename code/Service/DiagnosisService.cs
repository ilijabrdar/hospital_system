/***********************************************************************
 * Module:  DiagnosisService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DiagnosisService
 ***********************************************************************/

using bolnica.Repository;
using bolnica.Service;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;

namespace Service
{
    public class DiagnosisService : IDiagnosisService
    {

        private IDiagnosisRepository _repository;

        public DiagnosisService(IDiagnosisRepository repository)
        {
            _repository = repository;
        }

   

        public Diagnosis Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Diagnosis> GetAll()
        {
            return _repository.GetAll();
        }

        public Diagnosis RecommendDiagnosisBasedOnSymptoms(Symptom symptom, Diagnosis diagnosis)
        {
            throw new NotImplementedException();
        }

    }
}