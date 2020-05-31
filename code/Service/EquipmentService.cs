/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using bolnica.Service;
using Model.Director;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class EquipmentService : IEquipmentService
   {

        private IEquipmentRepository _repository;

        public EquipmentService(IEquipmentRepository repository)
        {
            _repository = repository;
        }

        public Room[] GetRoomsContainingEquipment(string name) //TODO: GetRoomsContainingEquipment
        {
            throw new NotImplementedException();
        }

        public Equipment Save(Equipment entity)
        {
            return _repository.Save(entity);
        }

        public void Delete(Equipment entity)
        {
            _repository.Delete(entity);
        }

        public void Edit(Equipment entity)
        {
            _repository.Edit(entity);
        }

        IEnumerable<Equipment> IService<Equipment, long>.GetAll()
        {
            return _repository.GetAll();
        }

        public Equipment Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Equipment> getConsumableEquipment() => _repository.getConsumableEquipment();

        public IEnumerable<Equipment> getInconsumableEquipment() => _repository.getInconsumableEquipment();
    }
}