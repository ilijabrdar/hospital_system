using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
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

        List<Hospitalization> GetHospitalizationsByRoomAndPeriod(Room room, Period period);

    }
}
