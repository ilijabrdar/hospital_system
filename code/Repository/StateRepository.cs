using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Repository.CSV;
using Model.Users;
using Repository;

namespace bolnica.Repository
{
    public class StateRepository : CSVGetterRepository<State, long>, IStateRepository ,IEagerRepository<State, long>
    {
        private readonly IEagerRepository<Town, long> _townRepository;

        public StateRepository(ICSVStream<State> stream, ISequencer<long> sequencer, IEagerRepository<Town, long> townRepository) : base(stream, sequencer)
        {
            _townRepository = townRepository;
        }

        public IEnumerable<State> GetAllEager()
        {
            List<Town> towns = _townRepository.GetAllEager().ToList();
            List<State> states = GetAll().ToList();
            Join(towns, states);
            return states;
        }

        private void Join(List<Town> towns, List<State> states)
        {
            for (int i = 0; i < states.Count; i++)
            {
                List<Town> oldTowns = states[i].GetTown();
                for (int j = 0; j < oldTowns.Count; j++)
                    oldTowns[j] = GetTownByID(towns, oldTowns[i].GetId());
            }
        }

        private Town GetTownByID(List<Town> towns, long id)
        {
            foreach (Town town in towns)
                if (town.GetId() == id)
                    return town;
            return null;
        }

        public State GetEager(long id)
        {
            State state = this.Get(id);
            List<Town> towns = state.GetTown();
            for(int i = 0; i < state.GetTown().Count; i++)
            {
                towns[i] = _townRepository.GetEager(towns[i].GetId());
            }
            return state;
        }
    }
}
