using Model.PatientSecretary;
using Repository;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
    public interface IDiagnosisRepository : IGetterRepository<Diagnosis, long>
    {
}
}
