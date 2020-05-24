using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public interface IHospitalizationController
    {
        Hospitalization CreateHospitalization(Hospitalization hospitalization);
        Boolean DeleteHospitalization(Hospitalization hospitalization);
    }
}
