

using bolnica.Controller;
using bolnica.Service;
using Model.Director;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class RenovationController : IRenovationController
   {
        private readonly IRenovationService _service;

        public RenovationController(IRenovationService service)
        {
            _service = service;
        }
        public void Delete(Renovation entity)
        {
            _service.Delete(entity);
        }

        public void Edit(Renovation entity)
        {
            _service.Edit(entity);
        }

        public Renovation Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Renovation> GetAll()
        {
            return _service.GetAll();
        }

        public Renovation Save(Renovation entity)
        {
            return _service.Save(entity);
        }
    }
}