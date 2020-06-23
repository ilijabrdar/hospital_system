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
        private IPrescriptionService _prescriptionService;

        public PrescriptionController(IPrescriptionService service)
        {
            _prescriptionService = service;
        }

        public void Delete(Prescription entity)
        {
            _prescriptionService.Delete(entity);
        }

        public void Edit(Prescription entity)
        {
            _prescriptionService.Edit(entity);
        }

        public Prescription Get(long id)
        {
            return _prescriptionService.Get(id);
        }

        public IEnumerable<Prescription> GetAll()
        {
            return _prescriptionService.GetAll();
        }

        public Prescription Save(Prescription entity)
        {
            return _prescriptionService.Save(entity);
        }
    }
}