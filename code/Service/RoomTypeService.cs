/***********************************************************************
 * Module:  RoomTypeService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.RoomTypeService
 ***********************************************************************/

using Model.Director;
using Repository;
using System;
using System.Collections.Generic;
using System.Web.Management;

namespace Service
{
   public class RoomTypeService : IService<RoomType, long>
   {
        private readonly IRoomTypeRepository _repository;

      //private Repository.IRoomTypeRepository _roomTypeRepository;
        
        public RoomTypeService(IRoomTypeRepository repository)
        {
            _repository = repository;
        }

        

        public object Delete()
        {
            throw new NotImplementedException();
        }

        public void Delete(RoomType entity)
        {
            _repository.Delete(entity);
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }

        public void Edit(RoomType entity)
        {
            _repository.Edit(entity);
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }

        

        public RoomType Save(RoomType entity)
        {
            return _repository.Save(entity);
        }

        IEnumerable<RoomType> IService<RoomType, long>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}