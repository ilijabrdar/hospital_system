
using bolnica.Service;
using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingrerdientRepository;

        public IngredientService(IIngredientRepository repository)
        {
            _ingrerdientRepository = repository;
        }

        public void Delete(Ingredient entity)
        {
            _ingrerdientRepository.Delete(entity);
        }


        public void Edit(Ingredient entity)
        {
            _ingrerdientRepository.Edit(entity);
        }

        public Ingredient Get(long id)
        {
            return _ingrerdientRepository.Get(id);
        }

        public Ingredient Save(Ingredient entity)
        {
            return _ingrerdientRepository.Save(entity);
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _ingrerdientRepository.GetAll();
        }
    }
}