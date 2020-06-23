using bolnica.Service;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    public class SymptomController : ISymptomController
    {
        private readonly ISymptomService _symptomService;

        public SymptomController(ISymptomService service)
        {
            _symptomService = service;
        }

        public void Delete(Symptom entity)
        {
            _symptomService.Delete(entity);
        }

        public void Edit(Symptom entity)
        {
            _symptomService.Edit(entity);
        }

        public Symptom Get(long id)
        {
            return _symptomService.Get(id);
        }

        public IEnumerable<Symptom> GetAll()
        {
            return _symptomService.GetAll();
        }

        public Symptom Save(Symptom entity)
        {
            return _symptomService.Save(entity);
        }
    }
}
