/***********************************************************************
 * Module:  HospitalizationService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.HospitalizationService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using System;

namespace Controller
{
    public class HospitalizationController : IHospitalizationController
    {
        private IHospitalizationService _service;

        public HospitalizationController(IHospitalizationService service)
        {
            _service = service;
        }

        public Hospitalization CreateHospitalization(Hospitalization hospitalization)
        {
            throw new NotImplementedException();
        }

        public bool DeleteHospitalization(Hospitalization hospitalization)
        {
            throw new NotImplementedException();
        }
    }
}