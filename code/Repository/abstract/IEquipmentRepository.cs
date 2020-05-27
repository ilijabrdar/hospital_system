/***********************************************************************
 * Module:  IEquipmentRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IEquipmentRepository
 ***********************************************************************/

using bolnica.Repository;
using Model.Director;
using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IEquipmentRepository : IRepository<Equipment,long>
   {
        Room[] GetRoomsContainingEquipment(String name);

        IEnumerable<Equipment> getConsumableEquipment();

        IEnumerable<Equipment> getInconsumableEquipment();
    }
}