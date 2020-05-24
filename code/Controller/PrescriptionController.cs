/***********************************************************************
 * Module:  PrescriptionService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.PrescriptionService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.PatientSecretary;
using System;
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

        public Prescription CreatePrescription(Prescription prescription, Examination examination)
        {
            throw new NotImplementedException();
        }
    }
}