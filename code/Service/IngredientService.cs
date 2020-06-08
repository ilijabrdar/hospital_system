/***********************************************************************
 * Module:  IngredientService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.IngredientService
 ***********************************************************************/

using bolnica.Service;
using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _repository;

        public IngredientService(IIngredientRepository repository)
        {
            _repository = repository;
        }

        public void Delete(Ingredient entity)
        {
            _repository.Delete(entity);
        }


        public void Edit(Ingredient entity)
        {
            _repository.Edit(entity);
        }

        public Ingredient Get(long id)
        {
            return _repository.Get(id);
        }

        public Ingredient Save(Ingredient entity)
        {
            return _repository.Save(entity);
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _repository.GetAll();
        }
    }
}