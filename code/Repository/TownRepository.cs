using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Users;

namespace bolnica.Repository
{
    public class TownRepository : CSVRepository<Town, long>
    {
        public TownRepository(ICSVStream<Town> stream, ISequencer<long> sequencer) : base(stream, sequencer)
        {
        }
    }
}
