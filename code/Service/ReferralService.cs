/***********************************************************************
 * Module:  ReferralService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ReferralService
 ***********************************************************************/

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
        private IReferralRepository _repository;

        public void Delete(Referral entity)
        {
            _repository.Delete(entity);
        }

        public void Edit(Referral entity)
        {
            _repository.Edit(entity);
        }

        public Referral Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Referral> GetAll()
        {
            return _repository.GetAll();
        }

        public Referral Save(Referral entity)
        {
            return _repository.Save(entity);
        }
    }
}