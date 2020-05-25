/***********************************************************************
 * Module:  IRoomRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IRoomRepository
 ***********************************************************************/

using bolnica.Repository;
using Model.Director;
using System;

namespace Repository
{
   public interface IRoomRepository : IRepository<Room, long>, IGetterRepository<Room, long>, IEagerRepository<Room, long>
    {
      int GetVacantRooms();
      int GetRoomByID();
   }
}