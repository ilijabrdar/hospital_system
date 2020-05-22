/***********************************************************************
 * Module:  RoomService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.RoomService
 ***********************************************************************/

using Model.Director;
using Repository;
using System;

namespace Service
{
   public class RoomService : IService<Room,long>
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

        public Room Save(Room entity)
        {
            return _repository.Save(entity);
        }

  
   
   }
}