using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Service;
using Model.Users;

namespace bolnica.Controller
{
    public class TownController : ITownController
    {
        ITownService _service;

        public TownController(ITownService service)
        {
            _service = service;
        }
        public Town Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Town> GetAll()
        {
            return _service.GetAll();
        }
    }
}
