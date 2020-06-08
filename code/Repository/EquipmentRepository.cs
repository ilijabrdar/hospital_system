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

        public IEnumerable<Equipment> getConsumableEquipment()
        {
            return (IEnumerable<Equipment>) base.GetAll().Where(equipment => equipment.Type == EquipmentType.Consumable);
        }

        public IEnumerable<Equipment> getInconsumableEquipment()
        {
            return (IEnumerable<Equipment>) base.GetAll().Where(equipment => equipment.Type == EquipmentType.Inconsumable);
        }

        public Room[] GetRoomsContainingEquipment(string name)
        {
            throw new NotImplementedException();
        }

    }
}