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
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;
        }
        public Room Save(Room entity)
        {
            return _service.Save(entity);
        }

        public IEnumerable<Room> GetAll()
        {
            return _service.GetAll();
        }

        public void Edit(Room entity)
        {
            _service.Edit(entity);
        }

        public void Delete(Room entity)
        {
            _service.Delete(entity);
        }

        public Room Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Room> GetRoomsContainingEquipment(Equipment equipment)
        {
            return _service.GetRoomsCointainingEquipment(equipment);
        }

        public bool CheckRoomCodeUnique(String name)
        {
            return _service.CheckRoomCodeUnique(name);
        }

        public List<Room> GetRoomsForHospitalization()
        {
            return _service.GetRoomsForHospitalization();
        }

        public void CheckHospitalizationDurationInRoom()
        {
            _service.CheckHospitalizationDurationInRoom();
        }

    }
}