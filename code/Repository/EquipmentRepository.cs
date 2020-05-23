/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using bolnica.Repository;
using Model.Director;
using System;

namespace Repository
{
   public class EquipmentRepository : CSVRepository<Equipment,long>, IEquipmentRepository
   {
      private String FilePath;
      public EquipmentRepository(ICSVStream<Equipment> stream, ISequencer<long> sequencer)
           : base(stream, sequencer)
        {

        }

        public Room[] GetRoomsContainingEquipment(string name)
        {
            throw new NotImplementedException();
        }
    }
}