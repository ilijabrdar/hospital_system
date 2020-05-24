using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
    interface IAnemenesisRepository
    {
        Anemnesis[] createAnemnesis(Anemnesis anemnesis, Examination examination);
    }
}
