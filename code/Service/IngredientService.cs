/***********************************************************************
 * Module:  IngredientService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.IngredientService
 ***********************************************************************/

using Model.PatientSecretary;
using Repository;
using System;

namespace Service
{
    public class IngredientService : IService<Ingredient, long>
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

        public object Edit()
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
    }
}