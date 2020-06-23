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

        Boolean CheckEquipmentNameUnique(String name);

        IEnumerable<Equipment> getConsumableEquipment();

        IEnumerable<Equipment> getInconsumableEquipment();
    }
}
