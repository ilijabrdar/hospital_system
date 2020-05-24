/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.Director;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class EquipmentController : IEquipmentController
   {
        private readonly IEquipmentService _service;

        public EquipmentController(IEquipmentService service)
        {
            _service = service;
        }
        public Equipment Save(Equipment entity)
        {
            return _service.Save(entity);
        }

        public void Delete(Equipment entity)
        {
            _service.Delete(entity);
        }

        public void Edit(Equipment entity)
        {
            _service.Edit(entity);
        }


        public Room[] GetRoomsContainingEquipment(string name)
        {
            throw new NotImplementedException();
        }

        public Equipment Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _service.GetAll();
        }
    }
}