
using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class SpecialityController : ISpecialityController
    {
        private ISpecialityService _service;

        public SpecialityController(ISpecialityService service)
        {
            _service = service;
        }

        public void Delete(Speciality entity)
        {
            _service.Delete(entity);
        }

        public void Edit(Speciality entity)
        {
            _service.Edit(entity);
        }

        public Speciality Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Speciality> GetAll()
        {
            return _service.GetAll();
        }

        public Speciality Save(Speciality entity)
        {
            return _service.Save(entity);
        }
    }
}