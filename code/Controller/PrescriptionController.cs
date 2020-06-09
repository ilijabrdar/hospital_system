/***********************************************************************
 * Module:  PrescriptionService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.PrescriptionService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Drawing.Text;

namespace Controller
{
    public class PrescriptionController : IPrescriptionController
    {
        private IPrescriptionService _service;

        public PrescriptionController(IPrescriptionService service)
        {
            _service = service;
        }

        public void Delete(Prescription entity)
        {
            _service.Delete(entity);
        }

        public void Edit(Prescription entity)
        {
            _service.Edit(entity);
        }

        public Prescription Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Prescription> GetAll()
        {
            return _service.GetAll();
        }

        public Prescription Save(Prescription entity)
        {
            return _service.Save(entity);
        }
    }
}