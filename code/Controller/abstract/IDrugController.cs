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
        Boolean CheckDrugNameUnique(String name);

        List<Drug> GetNotApprovedDrugs();
    }
}
