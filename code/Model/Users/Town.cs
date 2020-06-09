

using System;
using System.Collections.Generic;

namespace Model.Users
{
   public class Town : Repository.IIdentifiable<long>
   {
        public long Id;
        public String Name { get; set; }
        public String PostalNumber { get; set; }
        public State State { get; set; }

        private List<Address> address;
      
        public Town(long id, string name, string postalNumber, State state)
        {
            Id = id;
            Name = name;
            PostalNumber = postalNumber;
            State = state;
            address = new List<Address>();
        }

        public Town(long id)
        {
            Id = id;
        }

        public Town(long id, long stateID)
        {
            Id = id;
            State = new State(stateID);
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
            return State;
        }
      
        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newState</param>
        public void SetState(State newState)
        {
            if (State != newState)
            {
            if (State != null)
            {
                State oldState = State;
                State = null;
                oldState.RemoveTown(this);
            }
            if (newState != null)
            {
                State = newState;
                State.AddTown(this);
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