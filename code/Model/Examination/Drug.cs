
using Repository;
using System;
using System.Collections.Generic;

namespace Model.PatientSecretary
{
   public class Drug : IIdentifiable<long>
    {
      public String Name { get; set; }
        public long Id;
      public int Amount { get; set; }
      public Boolean Approved { get; set; }     
      public List<Ingredient> Ingredients { get; set; }
      public List<Drug> Alternative { get; set; }

      public Drug() { }
      public Drug (long id, String name, int amount, Boolean approved, List<Ingredient> ingredients, List<Drug> alternative)
        {
            this.Id = id;
            this.Name = name;
            this.Amount = amount;
            this.Approved = approved;
            this.Ingredients = ingredients;
            this.Alternative = alternative;
        }

        public Drug(long id)
        {
            Id = id;
        }

        public Drug(string name, int amount, bool approved, List<Ingredient> ingredients, List<Drug> alternative)
        {
            Name = name;
            Amount = amount;
            Approved = approved;
            Ingredients = ingredients;
            Alternative = alternative;
        }

        public long GetId()
        {
            return this.Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }
    }
}