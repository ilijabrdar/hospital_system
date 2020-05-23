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
        public object Delete()
        {
            throw new NotImplementedException();
        }

        public void Delete(Ingredient entity)
        {
            throw new NotImplementedException();
        }

        public object Edit()
        {
            throw new NotImplementedException();
        }

        public void Edit(Ingredient entity)
        {
            throw new NotImplementedException();
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }


        public Ingredient Save(Ingredient entity)
        {
            return _repository.Save(entity);
        }

        IEnumerable<Ingredient> IService<Ingredient, long>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}