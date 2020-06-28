using bolnica.Controller;
using bolnica.Service;
using Model.Director;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class RoomController : IRoomController
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService service)
        {
            _roomService = service;
        }
        public Room Save(Room entity)
        {
            return _roomService.Save(entity);
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomService.GetAll();
        }

        public void Edit(Room entity)
        {
            _roomService.Edit(entity);
        }

        public void Delete(Room entity)
        {
            _roomService.Delete(entity);
        }

        public Room Get(long id)
        {
            return _roomService.Get(id);
        }

        public IEnumerable<Room> GetRoomsContainingEquipment(Equipment equipment)
        {
            return _roomService.GetRoomsCointainingEquipment(equipment);
        }

        public bool CheckRoomCodeUnique(String name)
        {
            return _roomService.CheckRoomCodeUnique(name);
        }

        public List<Room> GetRoomsForHospitalization()
        {
            return _roomService.GetRoomsForHospitalization();
        }

        public void CheckHospitalizationDurationInRoom()
        {
            _roomService.CheckHospitalizationDurationInRoom();
        }

    }
}