using bolnica.Controller;
using bolnica.Service;
using Model.Director;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class RenovationController : IRenovationController
   {
        private readonly IRenovationService _renovationService;

        public RenovationController(IRenovationService service)
        {
            _renovationService = service;
        }
        public void Delete(Renovation entity)
        {
            _renovationService.Delete(entity);
        }

        public void Edit(Renovation entity)
        {
            _renovationService.Edit(entity);
        }

        public Renovation Get(long id)
        {
            return _renovationService.Get(id);
        }
        public IEnumerable<Renovation> GetAll()
        {
            return _renovationService.GetAll();
        }

        public Renovation Save(Renovation entity)
        {
            return _renovationService.Save(entity);
        }
    }
}