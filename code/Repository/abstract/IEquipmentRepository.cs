/***********************************************************************
 * Module:  IEquipmentRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IEquipmentRepository
 ***********************************************************************/

using bolnica.Repository;
using Model.Director;
using System;

namespace Repository
{
   public interface IEquipmentRepository : IRepository<Equipment,long>, IGetterRepository<Equipment, long>
   {
        Room[] GetRoomsContainingEquipment(String name);
    }
}