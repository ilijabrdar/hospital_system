using Controller;
using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public interface IEquipmentController : IController<Equipment,long>
    {
        Room[] GetRoomsContainingEquipment(String name);
    }
}
