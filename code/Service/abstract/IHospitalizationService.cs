using Model.Doctor;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IHospitalizationService : IService<Hospitalization, long>
    {
        List<Hospitalization> GetHospitalizationByDoctor(Doctor doctor);

    }
}
