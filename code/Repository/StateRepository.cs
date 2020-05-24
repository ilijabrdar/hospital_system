using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Repository.CSV;
using Model.Users;
using Repository;

namespace bolnica.Repository
{
    public class StateRepository : CSVGetterRepository<State, long>, IEagerRepository<State, long>
    {
        private readonly IRepository<Town, long> _townRepository;

        public StateRepository(ICSVStream<State> stream, ISequencer<long> sequencer) : base(stream, sequencer)
        {

        }

        public IEnumerable<State> getAllEager()
        {
            throw new NotImplementedException();
        }

        public State getEager(long id)
        {
            throw new NotImplementedException();
        }
    }
}
