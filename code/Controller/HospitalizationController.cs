using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class HospitalizationController : IHospitalizationController
    {
        private IHospitalizationService _hospitalizationService;

        public HospitalizationController(IHospitalizationService service)
        {
            _hospitalizationService = service;
        }

        public void Delete(Hospitalization entity)
        {
            _hospitalizationService.Delete(entity);
        }

        public void Edit(Hospitalization entity)
        {
            _hospitalizationService.Edit(entity);
        }

        public Hospitalization Get(long id)
        {
            return _hospitalizationService.Get(id);
        }

        public IEnumerable<Hospitalization> GetAll()
        {
            return _hospitalizationService.GetAll();
        }

        public Hospitalization Save(Hospitalization entity)
        {
            return _hospitalizationService.Save(entity);
        }

        public List<Hospitalization> GetHospitalizationByDoctor(Doctor doctor)
        {
            return _hospitalizationService.GetHospitalizationByDoctor(doctor);
        }
    }
}