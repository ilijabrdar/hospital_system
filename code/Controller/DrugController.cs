using bolnica.Controller;
using bolnica.Service;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class DrugController : IDrugController
    {
        private readonly IDrugService _drugService;

        public DrugController(IDrugService service)
        {
            _drugService = service;

        }

        public void Delete(Drug entity)
        {
            _drugService.Delete(entity);
        }

        public void Edit(Drug entity)
        {
            _drugService.Edit(entity);
        }

        public Drug Get(long id)
        {
            return _drugService.Get(id);
        }

        public IEnumerable<Drug> GetAll()
        {
            return _drugService.GetAll();
        }

        public List<Drug> GetNotApprovedDrugs()
        {
            return _drugService.GetNotApproved();
        }

        public Drug Save(Drug entity)
        {
            return _drugService.Save(entity);
        }

        public bool CheckDrugNameUnique(String name)
        {
            return _drugService.CheckDrugNameUnique(name);
        }
    }
}