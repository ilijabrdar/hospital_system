/***********************************************************************
 * Module:  DrugService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DrugService
 ***********************************************************************/

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

        public Drug CreateDrugBasedOnDiagnosis(Diagnosis diagnosis, Examination examination)
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
            return _service.Save(entity);
        }
    }
}