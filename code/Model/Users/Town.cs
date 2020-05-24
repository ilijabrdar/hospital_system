/***********************************************************************
 * Module:  Town.cs
 * Author:  Asus
 * Purpose: Definition of the Class Users.Town
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model.Users
{
   public class Town : Repository.IIdentifiable<long>
   {
        private long _id;
        public String Name { get; set; }
        public String PostalNumber { get; set; }
        public State state { get; set; }

        private List<Address> address;
      
        public Town(long id, string name, string postalNumber, State state)
        {
            _id = id;
            Name = name;
            PostalNumber = postalNumber;
            this.state = state;
            address = new List<Address>();
        }

        public Town(long id)
        {
            _id = id;
        }

        /// <pdGenerated>default getter</pdGenerated>
        public List<Address> GetAddress()
        {
            if (address == null)
            address = new List<Address>();
            return address;
        }
      
        /// <pdGenerated>default setter</pdGenerated>
        public void SetAddress(List<Address> newAddress)
        {
            RemoveAllAddress();
            foreach (Address oAddress in newAddress)
            AddAddress(oAddress);
        }
      
        /// <pdGenerated>default Add</pdGenerated>
        public void AddAddress(Address newAddress)
        {
            if (newAddress == null)
            return;
            if (this.address == null)
            this.address = new List<Address>();
            if (!this.address.Contains(newAddress))
            {
            this.address.Add(newAddress);
            newAddress.SetTown(this);      
            }
        }
      
        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveAddress(Address oldAddress)
        {
            if (oldAddress == null)
            return;
            if (this.address != null)
            if (this.address.Contains(oldAddress))
            {
                this.address.Remove(oldAddress);
                oldAddress.SetTown((Town)null);
            }
        }
      
        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllAddress()
        {
            if (address != null)
            {
                List<Address> tmpAddress = new List<Address>();
            foreach (Address oldAddress in address)
                tmpAddress.Add(oldAddress);
            address.Clear();
            foreach (Address oldAddress in tmpAddress)
                oldAddress.SetTown((Town)null);
            tmpAddress.Clear();
            }
        }
      
        /// <pdGenerated>default parent getter</pdGenerated>
        public State GetState()
        {
            return state;
        }
      
        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newState</param>
        public void SetState(State newState)
        {
            if (this.state != newState)
            {
            if (this.state != null)
            {
                State oldState = this.state;
                this.state = null;
                oldState.RemoveTown(this);
            }
            if (newState != null)
            {
                this.state = newState;
                this.state.AddTown(this);
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