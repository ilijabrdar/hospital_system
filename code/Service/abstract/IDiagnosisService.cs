using Model.PatientSecretary;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IDiagnosisService : IGetterService<Diagnosis,long>
    {
        Diagnosis RecommendDiagnosisBasedOnSymptoms(Symptom symptom, Diagnosis diagnosis);

    }
}
