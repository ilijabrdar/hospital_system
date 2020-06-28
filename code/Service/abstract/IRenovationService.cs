using Model.Director;
using Model.PatientSecretary;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IRenovationService : IService<Renovation,long>
    {
        void DeleteRenovationByRoom(Room room);

        IEnumerable<Renovation> GetRenovationsByRoomAndPeriod(Room room, Period period);
    }
}
