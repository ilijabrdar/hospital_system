using bolnica.Service;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public interface IRefferalController
    {
        Refferal CreateRefferal(Refferal refferal, Examination examination);
    }
}
