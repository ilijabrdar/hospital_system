using bolnica.Repository;
using Model.Director;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class RoomTypeRepository : CSVRepository<RoomType, long>, IRoomTypeRepository
    {

        public RoomTypeRepository(ICSVStream<RoomType> stream, ISequencer<long> sequencer)
            : base(stream, sequencer)
        {
        }

        public IEnumerable<RoomType> GetAllEager()
        {
            return GetAll();
        }

        public RoomType GetEager(long id)
        {
            return Get(id);
        }
    }
}
