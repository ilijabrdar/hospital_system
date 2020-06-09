using Model.PatientSecretary;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface ITherapyService : IService<Therapy,long>
    {
        Therapy AssignCurrentTherapy(PatientFile patientFile);
    }
}
