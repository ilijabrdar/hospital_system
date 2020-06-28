using bolnica.Controller;
using bolnica.Service;
using Model.Director;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class RoomTypeController : IRoomTypeController
   {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService service)
        {
            _roomTypeService = service;
        }

        public bool CheckRoomTypeUnique(string type)
        {
            return _roomTypeService.CheckRoomTypeUnique(type);
        }

        public void Delete(RoomType entity)
        {
            _roomTypeService.Delete(entity);
        }

        public void Edit(RoomType entity)
        {
            _roomTypeService.Edit(entity);
        }

        public RoomType Get(long id)
        {
            return _roomTypeService.Get(id);
        }

        public IEnumerable<RoomType> GetAll()
        {
            return _roomTypeService.GetAll();
        }

        public RoomType Save(RoomType entity)
        {
            return _roomTypeService.Save(entity);
        }

    }
}