using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Service;
using Model.Users;

namespace bolnica.Controller
{
    public class StateController : IStateController
    {
        IStateService _stateService;

        public StateController(IStateService service)
        {
            _stateService = service;
        }

        public State Get(long id)
        {
            return _stateService.Get(id);
        }

        public IEnumerable<State> GetAll()
        {
            return _stateService.GetAll();
        }
    }
}
