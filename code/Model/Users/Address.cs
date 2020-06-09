

using System;
using Repository;

namespace Model.Users
{
   public class Address : IIdentifiable<long>
   {
        private long _id;
        public String Street { get; set; }
        public int Number { get; set; }
        public int ApartmentNumber { get; set; }
        public String FullAddress { get; set; }

        public Town Town { get; set; }
      
        public Address(long id, string street, int number, int apartmentNumber, Town town)
        {
            _id = id;
            Street = street;
            Number = number;
            ApartmentNumber = apartmentNumber;
            Town = town;
            FullAddress = GetFullAddress();
        } 

        public Address(long id)
        {
            _id = id; 
        }

        public Address(long id, long townID, long stateID)
        {
            _id = id;
            Town = new Town(townID, stateID);
        }

        public String GetFullAddress()
        {
            return String.Join(", ", Street, Number, ApartmentNumber);
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
            return _id;
        }

        public void SetId(long id)
        {
            _id = id;
        }
    }
}