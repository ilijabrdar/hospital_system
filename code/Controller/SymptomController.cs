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
        private readonly ISymptomService _service;

        public SymptomController(ISymptomService service)
        {
            _service = service;
        }

        public void Delete(Symptom entity)
        {
            _service.Delete(entity);
        }

        public void Edit(Symptom entity)
        {
            _service.Edit(entity);
        }

        public Symptom Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Symptom> GetAll()
        {
            return _service.GetAll();
        }

        public Symptom Save(Symptom entity)
        {
            return _service.Save(entity);
        }
    }
}
