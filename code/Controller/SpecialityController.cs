using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class SpecialityController : ISpecialityController
    {
        private readonly ISpecialityService _specialityService;

        public SpecialityController(ISpecialityService service)
        {
            _specialityService = service;
        }

        public Speciality Get(long id)
        {
            return _specialityService.Get(id);
        }

        public IEnumerable<Speciality> GetAll()
        {
            return _specialityService.GetAll();
        }

    }
}