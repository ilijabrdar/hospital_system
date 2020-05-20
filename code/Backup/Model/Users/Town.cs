/***********************************************************************
 * Module:  Town.cs
 * Author:  Asus
 * Purpose: Definition of the Class Users.Town
 ***********************************************************************/

using System;

namespace Model.Users
{
   public class Town
   {
      public State state;
   
      private String Name;
      private String PostalNumber;
      
      private System.Collections.ArrayList address;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetAddress()
      {
         if (address == null)
            address = new System.Collections.ArrayList();
         return address;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetAddress(System.Collections.ArrayList newAddress)
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
            this.address = new System.Collections.ArrayList();
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
            System.Collections.ArrayList tmpAddress = new System.Collections.ArrayList();
            foreach (Address oldAddress in address)
               tmpAddress.Add(oldAddress);
            address.Clear();
            foreach (Address oldAddress in tmpAddress)
               oldAddress.SetTown((Town)null);
            tmpAddress.Clear();
         }
      }
      private State state;
      
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
   
   }
}