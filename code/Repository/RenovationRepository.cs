/***********************************************************************
 * Module:  RenovationService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.RenovationService
 ***********************************************************************/

using bolnica.Repository;
using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class RenovationRepository : CSVRepository<Renovation,long>, IRenovationRepository
   {
      private String FilePath;
        private readonly IRoomRepository _roomRepository;

        public RenovationRepository(ICSVStream<Renovation> stream, ISequencer<long> sequencer,IRoomRepository roomRepository)
     : base(stream, sequencer)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<Renovation> GetAllEager()
        {
            IEnumerable<Renovation> renovations = base.GetAll();
            IEnumerable<Room> rooms = _roomRepository.GetAllEager();
            BindRenovationWithRoom(renovations, rooms);

            return renovations;
        }

        private void BindRenovationWithRoom(IEnumerable<Renovation> renovations, IEnumerable<Room> rooms)
            => renovations.ToList().ForEach(renovation => renovation.Room = GetRoomByID(rooms, renovation.Room.GetId()));

        private Room GetRoomByID(IEnumerable<Room> rooms, long Id)
            => rooms.SingleOrDefault(room => room.GetId() == Id);

        public Renovation GetEager(long id)
        {
            Renovation renovation = base.Get(id);
            renovation.Room = _roomRepository.GetEager(renovation.Room.GetId());

            return renovation;
            
        }
    }
}