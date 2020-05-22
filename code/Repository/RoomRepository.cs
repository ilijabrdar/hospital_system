/***********************************************************************
 * Module:  RoomService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.RoomService
 ***********************************************************************/

using bolnica.Repository;
using Model.Director;
using System;
using System.Diagnostics.Eventing.Reader;

namespace Repository
{
   public class RoomRepository : CSVRepository<Room,long>, IRoomRepository
   {
      private String FilePath;
        public RoomRepository(ICSVStream<Room> stream, ISequencer<long> sequencer)
             : base(stream, sequencer)
        {

        }

        public int GetRoomByID()
        {
            throw new NotImplementedException();
        }

        public int GetVacantRooms()
        {
            throw new NotImplementedException();
        }

    }
}