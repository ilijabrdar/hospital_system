using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Service;
using Model.Users;

namespace bolnica.Controller
{
    class StateController : IStateController
    {
        IStateService _service;

        public StateController(IStateService service)
        {
            _service = service;
        }

        public State Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<State> GetAll()
        {
            return _service.GetAll();
        }
    }
}
