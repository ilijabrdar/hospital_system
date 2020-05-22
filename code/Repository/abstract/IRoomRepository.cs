/***********************************************************************
 * Module:  IRoomRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IRoomRepository
 ***********************************************************************/

using Model.Director;
using System;

namespace Repository
{
   public interface IRoomRepository : IRepository<Room, long>
   {
      int GetVacantRooms();
      int GetRoomByID();
   }
}