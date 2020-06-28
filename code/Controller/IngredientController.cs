using bolnica.Controller;
using bolnica.Service;
using Model.Director;
using Model.PatientSecretary;
using Service;
using System;
using System.Collections.Generic;

namespace Controller
{
   public class IngredientController : IIngredientController  
   {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService service)
        {
            _ingredientService = service;
        }

        public void Delete(Ingredient entity)
        {
            _ingredientService.Delete(entity);
        }

        public void Edit(Ingredient entity)
        {
            _ingredientService.Edit(entity);
        }

        public Ingredient Get(long id)
        {
            return _ingredientService.Get(id);
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _ingredientService.GetAll();
        }

        public Ingredient Save(Ingredient entity)
        {
            return _ingredientService.Save(entity);
        }

    }
}