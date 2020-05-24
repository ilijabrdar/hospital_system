using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IReferalService 
    {
        Refferal CreateRefferal(Refferal refferal, Examination examination);
    }
}
