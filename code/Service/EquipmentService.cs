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
        public IRoomService roomService;

        public EquipmentService(IEquipmentRepository repository, IRoomService roomService)
        {
            _repository = repository;
            this.roomService = roomService;
        }

        public Equipment Save(Equipment entity)
        {
            return _repository.Save(entity);
        }

        public void Delete(Equipment entity)
        {
            roomService.DeleteEquipmentFromRooms(entity);
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

        public IEnumerable<Equipment> GetConsumableEquipment()
        {
            return _repository.getConsumableEquipment();
        }
        public IEnumerable<Equipment> GetInconsumableEquipment()
        {
            return _repository.getInconsumableEquipment();
        }

        public bool CheckEquipmentNameUnique(String name)
        {
            foreach (Equipment equipment in GetAll())
                if (equipment.Name.Equals(name))
                    return false;

            return true;
        }
    }
}