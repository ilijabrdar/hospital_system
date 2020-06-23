

using bolnica.Service;
using Model.Director;
using Model.Users;
using Repository;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Service
{
   public class RoomService : IRoomService
   {
        private readonly IRoomRepository _repository;
        public IRenovationService renovationService;
        public IBusinessDayService businessDayService;

        public RoomService(IRoomRepository repository, IRenovationService renovationService, IBusinessDayService businessDayService)
        {
            _repository = repository;
            this.renovationService = renovationService;
            this.businessDayService = businessDayService;
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
            businessDayService.DeleteBusinessDayByRoom(entity);
            renovationService.DeleteRenovationByRoom(entity);
            _repository.Delete(entity);
        }

        public Room Get(long id)
        {
            return _repository.GetEager(id);
        }

        public IEnumerable<Room> GetRoomsCointainingEquipment(Equipment equipment)
        {
            IEnumerable<Room> rooms = this.GetAll();
            List<Room> result = new List<Room>();
            foreach (Room room in rooms)
            {
                //if (room.Equipment_inventory.ContainsKey(equipment))
                //{
                //    result.Add(room);
                //}

                foreach (KeyValuePair<Equipment, int> pair in room.Equipment_inventory)
                {
                    if (pair.Key.Id == equipment.Id)
                    {
                        result.Add(room);
                    }
                }
            }

            return result;
        }

        List<Room> IRoomService.GetVacantRooms()
        {
            throw new NotImplementedException();
        }

        public void DeleteRoomsByRoomType(RoomType roomType)
        {
            foreach (Room room in GetAll())
            {
                if (room.RoomType.Id == roomType.Id)
                    Delete(room);
            }
        }

        public void DeleteEquipmentFromRooms(Equipment equipment)
        {

            foreach (Room room in GetAll())
            {
                foreach (Equipment eq in room.Equipment_inventory.Keys)
                {
                    if (eq.Id == equipment.Id)
                    {
                        room.Equipment_inventory.Remove(eq);
                        Edit(room);
                        break;
                    }
                }
            }
        }

        public bool CheckRoomCodeUnique(string roomCode)
        {
            foreach (Room room in GetAll())
                if (room.RoomCode.Equals(roomCode))
                    return false;

            return true;
        }
    }
}