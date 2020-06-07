
using Repository;
using System;

namespace Model.PatientSecretary
{
   public class Drug : IIdentifiable<long>
    {
      public String Name { get; set; }
      public long Id { get; set; }
      public int Amount { get; set; }
      public Boolean Approved = false;
      
      public Ingredient[] ingredient { get; set; }
      public Drug[] Alternative { get; set; }

        public Drug(long id)
        {
            Id = id;
        }

        public Drug (long id, String name, int ammount, Boolean approved, Ingredient[] ing, Drug[] alter)
        {
            this.Id = id;
            this.Name = name;
            this.Amount = ammount;
            this.Approved = approved;
            this.ingredient = ing;
            this.Alternative = alter;
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