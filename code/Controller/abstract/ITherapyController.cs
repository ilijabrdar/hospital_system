using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
   public interface ITherapyController
    {
        Therapy CreateTherapy(Therapy therapy, Examination examination);
        Therapy CreateCurrentTherapy(PatientFile patientFile);
    }
}
