

using Repository;
using System;

namespace Model.Director
{
    public enum EquipmentType
    {
        Consumable,
        Inconsumable,

    }
    public class Equipment : IIdentifiable<long>
    {
          public EquipmentType Type { get; set; }
          public String Name { get; set; }
          public int Amount { get; set; }
          public long Id { get; set; }

          public Equipment (long id, EquipmentType et, String name, int amount)
          {
                this.Id = id;
                this.Type = et;
                this.Name = name;
                this.Amount = amount;
          }

        public Equipment(EquipmentType type, string name, int amount)
        {
            Type = type;
            Name = name;
            Amount = amount;
        }

        public Equipment(long id)
        {
            this.Id = id;
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }

    }
}
