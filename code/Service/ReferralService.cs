using bolnica.Service;
using Model.Doctor;
using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class ReferralService : IReferralService
    {
        private IReferralRepository _referralRepository;

        public ReferralService(IReferralRepository repository)
        {
            _referralRepository = repository;
        }

        public void Delete(Referral entity)
        {
            _referralRepository.Delete(entity);
        }

        public void Edit(Referral entity)
        {
            _referralRepository.Edit(entity);
        }

        public Referral Get(long id)
        {
            return _referralRepository.Get(id);
        }

        public IEnumerable<Referral> GetAll()
        {
            return _referralRepository.GetAll();
        }

        public Referral Save(Referral entity)
        {
            return _referralRepository.Save(entity);
        }
    }
}