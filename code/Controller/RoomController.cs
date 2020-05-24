/***********************************************************************
 * Module:  RoomService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.RoomService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.Director;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class RoomController : IRoomController
   {
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;
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

        public IEnumerable<Room> GetVacantRooms()
        {
            throw new NotImplementedException();
        }

        public bool AddEquipment(Equipment equipment, Room room)
        {
            throw new NotImplementedException();
        }

        public bool ChangeRoomType(Room room, RoomType roomType)
        {
            throw new NotImplementedException();
        }

        public Room Get(long id)
        {
            return _service.Get(id);
        }
    }
}