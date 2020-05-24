/***********************************************************************
 * Module:  IngredientService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.IngredientService
 ***********************************************************************/

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
        private readonly IIngredientService _service;

        public IngredientController(IIngredientService service)
        {
            _service = service;
        }



        public void Delete(Ingredient entity)
        {
            _service.Delete(entity);
        }



        public void Edit(Ingredient entity)
        {
            _service.Edit(entity);
        }

        public Ingredient Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Ingredient> GetAll()
        {
            return _service.GetAll();
        }

        public Ingredient Save(Ingredient entity)
        {
            return _service.Save(entity);
        }


    }
}