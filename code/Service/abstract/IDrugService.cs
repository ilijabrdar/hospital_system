using Model.PatientSecretary;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IDrugService : IService<Drug, long>
    {
        Drug RecommendDrugBasedOnDiagnosis(Diagnosis diagnosis);

        Drug AddAlternativeDrug(Drug originalDrug, Drug alternativeDrug);

        Boolean CheckDrugNameUnique(Drug drug);

        Drug ApproveDrug(Drug drug);

        List<Drug> GetAlternativeDrug(Drug drug);

        List<Drug> GetNotApproved();
    }
}
