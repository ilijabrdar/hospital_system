using bolnica.Controller;
using bolnica.Service;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class DiagnosisController : IDiagnosisController
    {
        private readonly IDiagnosisService _diagnosisService;
        public DiagnosisController(IDiagnosisService service)
        {
            _diagnosisService = service;
        }

        public Diagnosis Get(long id)
        {
            return _diagnosisService.Get(id);
        }

        public IEnumerable<Diagnosis> GetAll()
        {
            return _diagnosisService.GetAll();
        }

        public Diagnosis RecommendDiagnosisBasedOnSymptoms(Symptom symptom, Diagnosis diagnosis)
        {
            throw new NotImplementedException();
        }

    }
}