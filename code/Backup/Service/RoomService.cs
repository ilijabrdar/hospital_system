/***********************************************************************
 * Module:  RoomService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.RoomService
 ***********************************************************************/

using System;

namespace Service
{
   public class RoomService : IService
   {
      public Boolean ChangeRoomType(Room room, RoomType roomType)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean AddEquipment(Equipment equipment, Model.Director.Room room)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Director.Room[] GetVacantRooms()
      {
         // TODO: implement
         return null;
      }
   
      private Repository.IRoomRepository _roomRepository;
   
   }
}