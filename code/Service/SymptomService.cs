using bolnica.Service;
using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class SymptomService : ISymptomService
    {
        private readonly ISymptomRepository _repository;

        public SymptomService(ISymptomRepository repository)
        {
            _repository = repository;
        }

        public void Delete(Symptom entity)
        {
            _repository.Delete(entity);
        }

        public void Edit(Symptom entity)
        {
            _repository.Edit(entity);
        }

        public Symptom Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Symptom> GetAll()
        {
            return _repository.GetAll();
        }

        public Symptom Save(Symptom entity)
        {
            return _repository.Save(entity);
        }
    }
 }

