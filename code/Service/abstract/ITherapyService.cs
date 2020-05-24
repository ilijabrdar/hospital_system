using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface ITherapyService 

    {
        Therapy CreateTherapy(Therapy therapy, Examination examination);
        Therapy CreateCurrentTherapy(PatientFile patientFile);
    }
}
