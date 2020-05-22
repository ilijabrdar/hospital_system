using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Users;

namespace bolnica.Repository
{
    public class StateRepository : CSVRepository<State, long>
    {
        public StateRepository(ICSVStream<State> stream, ISequencer<long> sequencer) : base(stream, sequencer)
        {

        }
    }
}
