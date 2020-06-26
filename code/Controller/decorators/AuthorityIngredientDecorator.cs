using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.PatientSecretary;

namespace bolnica.Controller.decorators
{
    public class AuthorityIngredientDecorator : IIngredientController
    {
        private IIngredientController IngredientController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;
        public AuthorityIngredientDecorator(IIngredientController ingredientController, string role)
        {
            IngredientController = ingredientController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<String>() { "Director" };
            AuthorizedUsers["Edit"] = new List<String>() { "Director" };
            AuthorizedUsers["Get"] = new List<String>() { "Director", "Doctor" };
            AuthorizedUsers["GetAll"] = new List<String>() { "Director", "Doctor" };
            AuthorizedUsers["Save"] = new List<String>() { "Director" };
        }

        public void Delete(Ingredient entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                IngredientController.Delete(entity);
        }

        public void Edit(Ingredient entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                IngredientController.Delete(entity);
        }

        public Ingredient Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return IngredientController.Get(id);
            else
                return null;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return IngredientController.GetAll();
            else
                return null;
        }

        public Ingredient Save(Ingredient entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return IngredientController.Save(entity);
            else
                return null;
        }
    }
}
