/***********************************************************************
 * Module:  RoomTypeService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.RoomTypeService
 ***********************************************************************/

using Model.Director;
using Service;
using System;

namespace Controller
{
   public class RoomTypeController : IController<RoomType, long>
   {
      private readonly Service.IService<RoomType,long> _service;

        public RoomTypeController(IService<RoomType,long> service)
        {
            _service = service;
        }

        public object Delete()
        {
            throw new NotImplementedException();
        }

        public object Edit()
        {
            throw new NotImplementedException();
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
    }
}