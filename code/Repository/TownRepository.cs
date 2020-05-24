using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Users;
using bolnica.Repository.CSV;

namespace bolnica.Repository
{
    public class TownRepository : CSVGetterRepository<Town, long>, ITownRepository, IEagerRepository<Town, long>
    {
        

        public TownRepository(ICSVStream<Town> stream, ISequencer<long> sequencer) : base(stream, sequencer)
        {
        }

        public IEnumerable<Town> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Town GetEager(long id)
        {
            Town town = Get(id);
            return null;
        }
    }
}
