/***********************************************************************
 * Module:  RoomTypeService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.RoomTypeService
 ***********************************************************************/

using bolnica.Controller;
using Model.Director;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class RoomTypeController : IRoomTypeController
   {
      private readonly Service.IService<RoomType,long> _service;

        public RoomTypeController(IService<RoomType,long> service)
        {
            _service = service;
        }


        public void Delete(RoomType entity)
        {
            _service.Delete(entity);
        }

        public void Edit(RoomType entity)
        {
            _service.Edit(entity);
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }

        public object Save()
        {
            throw new NotImplementedException();
        }

        public RoomType Save(RoomType entity)
        {
            return _service.Save(entity);
        }

        IEnumerable<RoomType> IController<RoomType, long>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}