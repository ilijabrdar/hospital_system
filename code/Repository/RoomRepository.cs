/***********************************************************************
 * Module:  RoomService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.RoomService
 ***********************************************************************/

using bolnica.Repository;
using Model.Director;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace Repository
{
   public class RoomRepository : CSVRepository<Room,long>, IRoomRepository, IEagerRepository<Room,long>
   {
      private String FilePath;
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IEquipmentRepository _equipmentRepository;

        public RoomRepository(ICSVStream<Room> stream, ISequencer<long> sequencer, IRoomTypeRepository roomTypeRepository, IEquipmentRepository equipmentRepository)
             : base(stream, sequencer)
        {
            _roomTypeRepository = roomTypeRepository;
            _equipmentRepository = equipmentRepository;
        }

        public IEnumerable<Room> GetAllEager()
        {
            IEnumerable<Room> rooms = this.GetAll();
            IEnumerable<RoomType> roomTypes = _roomTypeRepository.GetAll();
            IEnumerable<Equipment> equipment = _equipmentRepository.GetAll();
            BindRoomsWithRoomTypes(rooms, roomTypes);
            BindRoomsWithEquipment(rooms, equipment);

            return rooms;
        }

        private void BindRoomsWithEquipment(IEnumerable<Room> rooms, IEnumerable<Equipment> equipment)
        {
            rooms = rooms.ToList();
            equipment = equipment.ToList();
            foreach (Room room in rooms)
            {
                foreach (KeyValuePair<Equipment,int> pair in room.Equipment_inventory)
                {
                    Equipment temp = equipment.SingleOrDefault(eq => eq.GetId() == pair.Key.GetId());
                    if (temp != default)
                    {
                        pair.Key.Name = temp.Name;
                        pair.Key.Type = temp.Type;
                        pair.Key.Amount = temp.Amount;
                    }
                }
            }
        }

        private void BindRoomsWithRoomTypes(IEnumerable<Room> rooms, IEnumerable<RoomType> roomTypes)
            => rooms.ToList().ForEach(room => room.RoomType = GetRoomTypeByID(roomTypes, room.RoomType.GetId()));

        private RoomType GetRoomTypeByID(IEnumerable<RoomType> roomTypes, long Id)
            => roomTypes.SingleOrDefault(roomType => roomType.GetId() == Id);

        public Room GetEager(long id)
        {
            Room room = base.Get(id);
            room.RoomType = _roomTypeRepository.Get(room.RoomType.Id);
            
            foreach (KeyValuePair<Equipment,int> pair in room.Equipment_inventory)
            {
                Equipment temp = _equipmentRepository.Get(pair.Key.id);
                pair.Key.Name = temp.Name;
                pair.Key.Type = temp.Type;
                pair.Key.Amount = temp.Amount;
            }
            return room;
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