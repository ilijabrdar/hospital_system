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
      private readonly IRoomTypeService _service;

        public RoomTypeController(IRoomTypeService service)
        {
            _service = service;
        }

        public bool CheckRoomTypeUnique(string type)
        {
            return _service.CheckRoomTypeUnique(type);
        }

        public void Delete(RoomType entity)
        {
            _service.Delete(entity);
        }

        public void Edit(RoomType entity)
        {
            _service.Edit(entity);
        }

        public RoomType Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<RoomType> GetAll()
        {
            return _service.GetAll();
        }

        public RoomType Save(RoomType entity)
        {
            return _service.Save(entity);
        }

    }
}