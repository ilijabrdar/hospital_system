using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Repository;
using Model.Users;

namespace bolnica.Service
{
    public class StateService : IStateService
    {
        IStateRepository _stateRepository;

        public StateService(IStateRepository repository)
        {
            _stateRepository = repository;
        }

        public State Get(long id)
        {
            return _stateRepository.Get(id);
        }

        public IEnumerable<State> GetAll()
        {
            return _stateRepository.GetAllEager();
        }
    }
}
