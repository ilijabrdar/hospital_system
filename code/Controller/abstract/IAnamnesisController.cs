using Controller;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    interface IAnamnesisController 
    {
        Anemnesis createAnemnesis(Anemnesis anamnesis, Examination examination);
    }
}
