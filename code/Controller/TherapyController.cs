/***********************************************************************
 * Module:  TherapyService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.TherapyService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.PatientSecretary;
using System;

namespace Controller
{
    public class TherapyController : ITherapyController
    {
        private ITherapyService _service;

        public TherapyController(ITherapyService service)
        {
            _service = service;
        }

        public Therapy CreateCurrentTherapy(PatientFile patientFile)
        {
            throw new NotImplementedException();
        }

        public Therapy CreateTherapy(Therapy therapy, Examination examination)
        {
            throw new NotImplementedException();
        }
    }
}