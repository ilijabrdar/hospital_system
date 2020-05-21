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
      private const string ENTITY_NAME = "Equipment";
      public EquipmentRepository(ICSVStream<Equipment> stream, ISequencer<long> sequencer)
           : base(ENTITY_NAME, stream, sequencer)
        {

        }
      


    }
}