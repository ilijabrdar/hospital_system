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
        private readonly ISymptomRepository _symptomRepository;

        public SymptomService(ISymptomRepository repository)
        {
            _symptomRepository = repository;
        }

        public void Delete(Symptom entity)
        {
            _symptomRepository.Delete(entity);
        }

        public void Edit(Symptom entity)
        {
            _symptomRepository.Edit(entity);
        }

        public Symptom Get(long id)
        {
            return _symptomRepository.Get(id);
        }

        public IEnumerable<Symptom> GetAll()
        {
            return _symptomRepository.GetAll();
        }

        public Symptom Save(Symptom entity)
        {
            return _symptomRepository.Save(entity);
        }
    }
 }

