using bolnica.Controller;
using bolnica.Service;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class TherapyController : ITherapyController
    {
        private ITherapyService _therapyService;

        public TherapyController(ITherapyService service)
        {
            _therapyService = service;
        }

        public void Delete(Therapy entity)
        {
            _therapyService.Delete(entity);
        }

        public void Edit(Therapy entity)
        {
            _therapyService.Edit(entity);
        }

        public Therapy Get(long id)
        {
            return _therapyService.Get(id);
        }

        public IEnumerable<Therapy> GetAll()
        {
            return _therapyService.GetAll();
        }

        public Therapy Save(Therapy entity)
        {
            return _therapyService.Save(entity);
        }
    }
}