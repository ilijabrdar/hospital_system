/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using System;

namespace Service
{
   public class EquipmentService// : IService
   {
      public Model.Director.Room[] GetRoomsContainingEquipment(String name)
      {
         // TODO: implement
         return null;
      }

        public object Save()
        {
            throw new NotImplementedException();
        }

        public object Delete()
        {
            throw new NotImplementedException();
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }

        private Repository.IEquipmentRepository _equipmentRepository;
   
   }
}