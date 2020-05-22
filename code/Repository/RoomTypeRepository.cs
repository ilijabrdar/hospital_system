/***********************************************************************
 * Module:  RoomTypeService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.RoomTypeService
 ***********************************************************************/

using bolnica.Repository;
using Model.Director;
using System;

namespace Repository
{
   public class RoomTypeRepository : CSVRepository<RoomType, long>, IRoomTypeRepository
   {

        public RoomTypeRepository(ICSVStream<RoomType> stream, ISequencer<long> sequencer)
            : base(stream, sequencer)
        {

        }

    }
}