/***********************************************************************
 * Module:  TherapyService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.TherapyService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class TherapyController : ITherapyController
    {
        private ITherapyService _service;

        public TherapyController(ITherapyService service)
        {
            _service = service;
        }

        public Therapy AssignCurrentTherapy(PatientFile patientFile)
        {
            throw new NotImplementedException();
        }

        public void Delete(Therapy entity)
        {
            _service.Delete(entity);
        }

        public void Edit(Therapy entity)
        {
            _service.Edit(entity);
        }

        public Therapy Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Therapy> GetAll()
        {
            return _service.GetAll();
        }

        public Therapy Save(Therapy entity)
        {
            return _service.Save(entity);
        }
    }
}