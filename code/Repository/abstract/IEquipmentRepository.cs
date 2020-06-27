
using bolnica.Repository;
using Model.Director;
using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IEquipmentRepository : IRepository<Equipment,long>
   {


        IEnumerable<Equipment> getConsumableEquipment();

        IEnumerable<Equipment> getInconsumableEquipment();
    }
}