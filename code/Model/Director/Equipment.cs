/***********************************************************************
 * Module:  Equipment.cs
 * Author:  david
 * Purpose: Definition of the Class Director.Equipment
 ***********************************************************************/

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
          public long id { get; set; }

          public Equipment (long id, EquipmentType et, String name, int amount)
          {
                this.id = id;
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
            this.id = id;
        }

        public long GetId()
        {
            return id;
        }

        public void SetId(long id)
        {
            this.id = id;
        }
    }
}
