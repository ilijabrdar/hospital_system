
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
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService service)
        {
            _equipmentService = service;
        }

        public Equipment Save(Equipment entity)
        {
            return _equipmentService.Save(entity);
        }

        public void Delete(Equipment entity)
        {
            _equipmentService.Delete(entity);
        }

        public void Edit(Equipment entity)
        {
            _equipmentService.Edit(entity);
        }

        public Equipment Get(long id)
        {
            return _equipmentService.Get(id);
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _equipmentService.GetAll();
        }

        public IEnumerable<Equipment> getConsumableEquipment()
        {
            return _equipmentService.GetConsumableEquipment();
        }

        public IEnumerable<Equipment> getInconsumableEquipment()
        {
            return _equipmentService.GetInconsumableEquipment();
        }

        public bool CheckEquipmentNameUnique(String name)
        {
            return _equipmentService.CheckEquipmentNameUnique(name);
        }
    }
}