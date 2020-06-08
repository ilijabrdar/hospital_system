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
        Drug CreateDrugBasedOnDiagnosis(Diagnosis diagnosis, Examination examination);

        Drug AddAlternativeDrug(Drug originalDrug, Drug alternativeDrug);

        Drug ApproveDrug(Drug drug);

        List<Drug> GetAlternativeDrug(Drug drug);

        List<Drug> GetNotApproved();
    }
}
