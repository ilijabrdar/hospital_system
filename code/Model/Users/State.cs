/***********************************************************************
 * Module:  State.cs
 * Author:  Asus
 * Purpose: Definition of the Class Users.State
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Model.Users
{
   public class State : Repository.IIdentifiable<long>
   {

      private long _id;
      public String Name { get; set; }
      public String Code { get; set; }

      private List<Town> town;

        public State(long id, String name, String code)
        {
            _id = id;
            Name = name;
            Code = code;
            town = new List<Town>();
        }
      
        public State(long id)
        {
            _id = id;
        }

      /// <pdGenerated>default getter</pdGenerated>
      public List<Town> GetTown()
      {
         if (town == null)
            town = new List<Town>();
         return town;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetTown(List<Town> newTown)
      {
         RemoveAllTown();
         foreach (Town oTown in newTown)
            AddTown(oTown);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddTown(Town newTown)
      {
         if (newTown == null)
            return;
         if (this.town == null)
            this.town = new List<Town>();
         if (!this.town.Contains(newTown))
         {
            this.town.Add(newTown);
            newTown.SetState(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveTown(Town oldTown)
      {
         if (oldTown == null)
            return;
         if (this.town != null)
            if (this.town.Contains(oldTown))
            {
               this.town.Remove(oldTown);
               oldTown.SetState((State)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllTown()
      {
         if (town != null)
         {
            List<Town> tmpTown = new List<Town>();
            foreach (Town oldTown in town)
               tmpTown.Add(oldTown);
            town.Clear();
            foreach (Town oldTown in tmpTown)
               oldTown.SetState((State)null);
            tmpTown.Clear();
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