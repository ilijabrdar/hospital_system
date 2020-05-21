/***********************************************************************
 * Module:  IngredientService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.IngredientService
 ***********************************************************************/

using Model.Director;
using Model.PatientSecretary;
using Service;
using System;

namespace Controller
{
   public class IngredientController : IController<Ingredient, long>
   {
        private readonly IService<Ingredient, long> _service;

        public IngredientController(IService<Ingredient, long> service)
        {
            _service = service;
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
            return _service.Save(entity);
        }
    }
}