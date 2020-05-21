/***********************************************************************
 * Module:  RoomService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.RoomService
 ***********************************************************************/

using Model.Director;
using System;

namespace Controller
{
   public class RoomController// : IController
   {
      public Boolean ChangeRoomType(Room room, RoomType roomType)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean AddEquipment(Equipment equipment, Model.Director.Room room)
      {
         // TODO: implement
         return false;
      }
      
      public Model.Director.Room[] GetVacantRooms()
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

        //private Service.IService _service;
   
   }
}