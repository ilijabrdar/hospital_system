using Model.Doctor;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IHospitalizationService :IService<Hospitalization, long>
    {
    }
}
