/***********************************************************************
 * Module:  ReferralService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ReferralService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class ReferralController : IRefferalController
    {
        private IReferalService _service;

        public ReferralController(IReferalService service)
        {
            _service = service;
        }

        public Refferal CreateRefferal(Refferal refferal, Examination examination)
        {
            throw new NotImplementedException();
        }

       
    }
}