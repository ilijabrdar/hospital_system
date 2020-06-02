/***********************************************************************
 * Module:  RoomService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.RoomService
 ***********************************************************************/

using bolnica.Service;
using Model.Director;
using Repository;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Service
{
   public class RoomService : IRoomService
   {
        private readonly IRoomRepository _repository;

        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }
      public Boolean ChangeRoomType(Room room, RoomType roomType)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean AddEquipment(Equipment equipment, Room room)
      {
         // TODO: implement
         return false;
      }
      
      public List<Room> GetVacantRooms()
      {
         // TODO: implement
         return null;
      }



        public IEnumerable<Room> GetAll()
        {
            return _repository.GetAllEager();
        }

        public Room Save(Room entity)
        {
            return _repository.Save(entity);
        }

        public void Edit(Room entity)
        {
            _repository.Edit(entity);
        }

        public void Delete(Room entity)
        {
            _repository.Delete(entity);
        }

        public Room Get(long id)
        {
            return _repository.GetEager(id);
        }
    }
}