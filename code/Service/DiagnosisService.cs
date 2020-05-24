/***********************************************************************
 * Module:  DiagnosisService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DiagnosisService
 ***********************************************************************/

using bolnica.Service;
using Model.PatientSecretary;
using System;

namespace Service
{
    public class DiagnosisService  : IDiagnosisService
    {
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