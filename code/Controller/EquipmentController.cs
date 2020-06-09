
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


        public Equipment Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _service.GetAll();
        }

        public IEnumerable<Equipment> getConsumableEquipment() => _service.GetConsumableEquipment();

        public IEnumerable<Equipment> getInconsumableEquipment() => _service.GetInconsumableEquipment();

        public bool CheckEquipmentNameUnique(Equipment equipment)
        {
            throw new NotImplementedException();
        }
    }
}