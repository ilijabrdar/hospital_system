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
        Boolean CheckDrugNameUnique(String name);

        List<Drug> GetNotApproved();
    }
}
