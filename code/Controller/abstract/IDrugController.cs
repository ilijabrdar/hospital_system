using Controller;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public interface IDrugController : IController<Drug,long>
    {
        Drug RecommendDrugBasedOnDiagnosis(Diagnosis diagnosis);

        Drug AddAlternativeDrug(Drug originalDrug, Drug alternativeDrug);

        Drug ApproveDrug(Drug drug);

        List<Drug> GetAlternativeDrugs(Drug drug);

        Boolean CheckDrugNameUnique(Drug drug);


        List<Drug> GetNotApprovedDrugs();
    }
}
