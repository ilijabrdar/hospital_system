/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using System;

namespace Service
{
   public class EquipmentService : IService
   {
      public Model.Director.Room[] GetRoomsContainingEquipment(String name)
      {
         // TODO: implement
         return null;
      }
   
      private Repository.IEquipmentRepository _equipmentRepository;
   
   }
}