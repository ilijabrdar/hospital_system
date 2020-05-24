/***********************************************************************
 * Module:  DiagnosisService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DiagnosisService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.PatientSecretary;
using System;

namespace Controller
{
    public class DiagnosisController : IDiagnosisController
    {
        private readonly IDiagnosisService _service;
        public DiagnosisController(IDiagnosisService service)
        {
            _service = service;
        }
        public Diagnosis CreateDiagnosis(Examination examination, Diagnosis diagnosis)
        {
            throw new NotImplementedException();
        }

        public Diagnosis CreateDiagnosisBasedOnSymptoms(Examination examinatio, Symptom symptom)
        {
            throw new NotImplementedException();
        }
    }
}