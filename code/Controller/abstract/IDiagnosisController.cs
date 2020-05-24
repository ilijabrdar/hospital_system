using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    interface IDiagnosisController
    {
        Diagnosis CreateDiagnosis(Examination examination, Diagnosis diagnosis);
        Diagnosis CreateDiagnosisBasedOnSymptoms(Examination examinatio,Symptom symptom);
    }
}
