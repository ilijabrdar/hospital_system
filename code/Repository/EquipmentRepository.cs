using bolnica.Repository;
using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class EquipmentRepository : CSVRepository<Equipment,long>, IEquipmentRepository
   {
      private String FilePath;
      public EquipmentRepository(ICSVStream<Equipment> stream, ISequencer<long> sequencer)
           : base(stream, sequencer)
        {

        }

        public IEnumerable<Equipment> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipment> getConsumableEquipment()
        {
            return (IEnumerable<Equipment>) base.GetAll().Where(equipment => equipment.Type == EquipmentType.Consumable);
        }

        public Equipment GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipment> getInconsumableEquipment()
        {
            return (IEnumerable<Equipment>) base.GetAll().Where(equipment => equipment.Type == EquipmentType.Inconsumable);
        }


    }
}