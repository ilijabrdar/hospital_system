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
        ITownService _townService;

        public TownController(ITownService service)
        {
            _townService = service;
        }
        public Town Get(long id)
        {
            return _townService.Get(id);
        }

        public IEnumerable<Town> GetAll()
        {
            return _townService.GetAll();
        }
    }
}
