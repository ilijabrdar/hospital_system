/***********************************************************************
 * Module:  IRoomRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IRoomRepository
 ***********************************************************************/

using System;

namespace Repository
{
   public interface IRoomRepository// : IRepository
   {
      int GetVacantRooms();
      int GetRoomByID();
   }
}