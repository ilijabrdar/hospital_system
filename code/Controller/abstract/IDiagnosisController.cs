using Controller;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    interface IDiagnosisController :IController<Diagnosis,long> 
    {
        Diagnosis RecommendDiagnosisBasedOnSymptoms(Symptom symptom, Diagnosis diagnosis);
    }
}
