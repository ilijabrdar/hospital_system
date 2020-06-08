
using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class SpecialityController : ISpecialityController
    {
        private readonly ISpecialityService _service;

        public SpecialityController(ISpecialityService service)
        {
            _service = service;
        }



        public Speciality Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Speciality> GetAll()
        {
            return _service.GetAll();
        }

    }
}