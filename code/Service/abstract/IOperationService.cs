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
    public interface IOperationService : IService<Operation, long>
    {
        List<Operation> GetOperationsByDoctor(Doctor doctor);

        List<Operation> GetOperationsByRoomAndPeriod(Room room, Period period);
    }
}
