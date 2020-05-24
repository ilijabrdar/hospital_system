using Model.Director;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IEquipmentService : IService<Equipment, long>
    {
        Room[] GetRoomsContainingEquipment(String name);
    }
}
