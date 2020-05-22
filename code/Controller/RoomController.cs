/***********************************************************************
 * Module:  RoomService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.RoomService
 ***********************************************************************/

using Model.Director;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class RoomController : IController<Room,long>
   {
        private readonly IService<Room, long> _service;

        public RoomController(IService<Room,long> service)
        {
            _service = service;
        }
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

        public Room Save(Room entity)
        {
            return _service.Save(entity);
        }


        public IEnumerable<Room> GetAll()
        {
            return _service.GetAll();
        }

        public void Edit(Room entity)
        {
            _service.Edit(entity);
        }

        public void Delete(Room entity)
        {
            _service.Delete(entity);
        }
    }
}