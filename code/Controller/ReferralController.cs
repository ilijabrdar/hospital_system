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
        private IReferralService _referralService;

        public ReferralController(IReferralService service)
        {
            _referralService = service;
        }

        public void Delete(Referral entity)
        {
            _referralService.Delete(entity);
        }

        public void Edit(Referral entity)
        {
            _referralService.Edit(entity);
        }

        public Referral Get(long id)
        {
            return _referralService.Get(id);
        }

        public IEnumerable<Referral> GetAll()
        {
            return _referralService.GetAll();
        }

        public Referral Save(Referral entity)
        {
            return _referralService.Save(entity);
        }
    }
}