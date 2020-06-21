

using Repository;
using System;

namespace Model.PatientSecretary
{
   public class Ingredient : IIdentifiable<long>
   {
      public string Name { get; set; }
      public int Quantity { get; set; }

        public Ingredient() { }
        public Ingredient(long id, string name, int quantity)
        {
            Quantity = quantity;
            Name = name;
            Id = id;
        }

        public Ingredient(string name, int quantity)
        {
            Quantity = quantity;
            Name = name;
        }

        public Ingredient(long id)
        {
            Id = id;
        }

        public long Id { get; set; }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}