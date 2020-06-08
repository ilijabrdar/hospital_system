using bolnica.Service;
using Model.Director;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class EquipmentService : IEquipmentService
   {

        private readonly IEquipmentRepository _repository;

        public EquipmentService(IEquipmentRepository repository)
        {
            _repository = repository;
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

       public IEnumerable<Equipment> GetAll()
        {
            return _repository.GetAll();
        }

        public Equipment Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Equipment> GetConsumableEquipment() => _repository.getConsumableEquipment();

        public IEnumerable<Equipment> GetInconsumableEquipment() => _repository.getInconsumableEquipment();

        public bool CheckEquipmentNameUnique(Equipment equipment)
        {
            throw new NotImplementedException();
        }
    }
}