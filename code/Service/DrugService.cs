/***********************************************************************
 * Module:  DrugService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DrugService
 ***********************************************************************/

using bolnica.Service;
using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class DrugService : IDrugService
   {
      private IDrugRepository _repository;

        public DrugService(IDrugRepository repository)
        {
            _repository = repository;
        }

        public Drug AddAlternativeDrug(Drug originalDrug, Drug alternativeDrug)
        {
            throw new NotImplementedException();
        }

        public Drug ApproveDrug(Drug drug)
        {
            throw new NotImplementedException();
        }

        public Drug CreateDrugBasedOnDiagnosis(Diagnosis diagnosis, Examination examination)
        {
            throw new NotImplementedException();
        }

        public void Delete(Drug entity)
        {
            _repository.Delete(entity);
        }

        public void Edit(Drug entity)
        {
            _repository.Edit(entity);
        }

        public Drug Get(long id)
        {
            return _repository.GetEager(id);
        }

        public IEnumerable<Drug> GetAll()
        {
            return _repository.GetAllEager();
        }

        public List<Drug> GetAlternativeDrug(Drug drug)
        {
            throw new NotImplementedException();
        }

        public List<Drug> GetNotApproved()
        {
            throw new NotImplementedException();
        }

        public Drug Save(Drug entity)
        {
            return _repository.Save(entity);
        }
    }
}