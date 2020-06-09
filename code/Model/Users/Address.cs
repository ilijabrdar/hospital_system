

using System;
using Repository;

namespace Model.Users
{
   public class Address : IIdentifiable<long>
   {
        public long Id { get; set; }
        public String Street { get; set; }
        public int Number { get; set; }
        public String FullAddress { get; set; }

        public Town Town { get; set; }
      
        public Address(long id, string street, int number, Town town)
        {
            Id = id;
            Street = street;
            Number = number;
            Town = town;
            FullAddress = GetFullAddress();
        } 

        public Address(long id)
        {
            Id = id; 
        }

        public Address(long id, long townID, long stateID)
        {
            Id = id;
            Town = new Town(townID, stateID);
        }

        public String GetFullAddress()
        {
            return String.Join(", ", Street, Number);
        }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Town GetTown()
        {
            return Town;
        }
      
        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newTown</param>
        public void SetTown(Town newTown)
        {
            if (Town != newTown)
            {
            if (Town != null)
            {
                Town oldTown = Town;
                Town = null;
                oldTown.RemoveAddress(this);
            }
            if (newTown != null)
            {
                Town = newTown;
                Town.AddAddress(this);
            }
            }
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}