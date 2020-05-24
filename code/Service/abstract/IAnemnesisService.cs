
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IAnemnesisService //: IExaminationService
    {
        Anemnesis[] createAnemnesis(Anemnesis anemnesis, Examination examination);
    }
}
