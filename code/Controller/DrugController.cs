

using bolnica.Controller;
using bolnica.Service;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class DrugController : IDrugController
    {
        private readonly IDrugService _service;

        public DrugController(IDrugService service)
        {
            _service = service;
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
            _service.Delete(entity);
        }

        public void Edit(Drug entity)
        {
            _service.Edit(entity);
        }

        public Drug Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Drug> GetAll()
        {
            return _service.GetAll();
        }

        public List<Drug> GetAlternativeDrugs(Drug drug)
        {
            throw new NotImplementedException();
        }

        public List<Drug> GetNotApprovedDrugs()
        {
            throw new NotImplementedException();
        }

        public Drug Save(Drug entity)
        {
            return _service.Save(entity);
        }

        public bool CheckDrugNameUnique(Drug drug)
        {
            throw new NotImplementedException();
        }
    }
}