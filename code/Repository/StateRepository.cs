using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Repository.CSV;
using Model.Users;
using Repository;

namespace bolnica.Repository
{
    public class StateRepository : CSVGetterRepository<State, long>, IStateRepository 
    {
        private readonly IEagerRepository<Town, long> _townRepository;

        public StateRepository(ICSVStream<State> stream, ISequencer<long> sequencer, IEagerRepository<Town, long> townRepository) : base(stream, sequencer)
        {
            _townRepository = townRepository;
        }

        public IEnumerable<State> GetAllEager()
        {
            List<State> states = GetAll().ToList();
            for (int i = 0; i < states.Count; i++)
                states[i] = GetEager(states[i].GetId());
            return states;
        }

        public State GetEager(long id)
        {
            State state = this.Get(id);
            List<Town> towns = state.GetTown();
            for(int i = 0; i < towns.Count; i++)
            {
                towns[i] = _townRepository.GetEager(towns[i].GetId());
            }
            return state;
        }
    }
}
