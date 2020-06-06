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
    public class ReferralController : IReferralController
    {
        private IReferralService _service;

        public ReferralController(IReferralService service)
        {
            _service = service;
        }

        public void Delete(Referral entity)
        {
            _service.Delete(entity);
        }

        public void Edit(Referral entity)
        {
            _service.Edit(entity);
        }

        public Referral Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Referral> GetAll()
        {
            return _service.GetAll();
        }

        public Referral Save(Referral entity)
        {
            return _service.Save(entity);
        }
    }
}