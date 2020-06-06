/***********************************************************************
 * Module:  HospitalizationService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.HospitalizationService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class HospitalizationController : IHospitalizationController
    {
        private IHospitalizationService _service;

        public HospitalizationController(IHospitalizationService service)
        {
            _service = service;
        }

        public void Delete(Hospitalization entity)
        {
            _service.Delete(entity);
        }

        public void Edit(Hospitalization entity)
        {
            _service.Edit(entity);
        }

        public Hospitalization Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Hospitalization> GetAll()
        {
            return _service.GetAll();
        }

        public Hospitalization Save(Hospitalization entity)
        {
            return _service.Save(entity);
        }
    }
}