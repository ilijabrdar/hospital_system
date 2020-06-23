
using bolnica.Service;
using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
   public class DrugService : IDrugService
   {
        private readonly IDrugRepository _repository;
        private readonly IIngredientService _ingredientService;
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

        public Drug RecommendDrugBasedOnDiagnosis(Diagnosis diagnosis)
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
            return _repository.GetNotApprovedDrugs();
        }

        public Drug Save(Drug entity)
        {
            return _repository.Save(entity);
        }

        public bool CheckDrugNameUnique(String name)
        {
            foreach (Drug drug in GetAll())
                if (drug.Name.Equals(name))
                    return false;

            return true;
        }
    }
}