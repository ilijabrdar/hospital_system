/***********************************************************************
 * Module:  Address.cs
 * Author:  Asus
 * Purpose: Definition of the Class Users.Address
 ***********************************************************************/

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

        private Town town;
      
        public Address(long id, string street, int number, int apartmentNumber, Town town)
        {
            _id = id;
            Street = street;
            Number = number;
            ApartmentNumber = apartmentNumber;
            this.town = town;
            _id = id;
        } 

        public Address(long id)
        {
            _id = id; 
        }

        public Address(long id, long townID, long stateID)
        {
            _id = id;
            town = new Town(townID, stateID);
        }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Town GetTown()
        {
            return town;
        }
      
        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newTown</param>
        public void SetTown(Town newTown)
        {
            if (this.town != newTown)
            {
            if (this.town != null)
            {
                Town oldTown = this.town;
                this.town = null;
                oldTown.RemoveAddress(this);
            }
            if (newTown != null)
            {
                this.town = newTown;
                this.town.AddAddress(this);
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