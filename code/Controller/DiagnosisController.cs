/***********************************************************************
 * Module:  DiagnosisService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DiagnosisService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class DiagnosisController : IDiagnosisController
    {
        private readonly IDiagnosisService _service;
        public DiagnosisController(IDiagnosisService service)
        {
            _service = service;
        }

        public Diagnosis Get(long id)
        {
            return _service.Get(id); throw new NotImplementedException();
        }

        public IEnumerable<Diagnosis> GetAll()
        {
            return _service.GetAll();
        }

        public Diagnosis RecommendDiagnosisBasedOnSymptoms(Symptom symptom, Diagnosis diagnosis)
        {
            throw new NotImplementedException();
        }

    }
}