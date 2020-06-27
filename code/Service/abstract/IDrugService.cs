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

        

        Boolean CheckDrugNameUnique(String name);





        List<Drug> GetNotApproved();
    }
}
