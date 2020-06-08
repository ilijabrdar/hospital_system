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
        IStateRepository _repository;

        public StateService(IStateRepository repository)
        {
            _repository = repository;
        }

        public State Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<State> GetAll()
        {
            return _repository.GetAllEager();
        }
    }
}
