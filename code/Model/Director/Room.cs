/***********************************************************************
 * Module:  Room.cs
 * Author:  david
 * Purpose: Definition of the Class Director.Room
 ***********************************************************************/

using Repository;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Model.Director
{
   public class Room : IIdentifiable<long>
   {
        public Dictionary<Equipment, int> Equipment_inventory { get; set; }

        public string RoomCode { get; set; }
        

        public long Id { get; set; }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public RoomType RoomType { get; set; }

        private System.Collections.ArrayList renovation;

        public Room(string roomCode, RoomType roomType, Dictionary<Equipment, int> equipment_inventory, ArrayList renovation)
        {
            Equipment_inventory = equipment_inventory;
            RoomCode = roomCode;

            this.RoomType = roomType;
            this.renovation = renovation;
        }




        public Room(long id, string roomCode, RoomType roomType, Dictionary<Equipment, int> equipment_inventory,   ArrayList renovation)
        {
            Equipment_inventory = equipment_inventory;
            RoomCode = roomCode;

            Id = id;
            this.RoomType = roomType;
            this.renovation = renovation;
        }

        public Room(long id)
        {
            Id = id;
        }




        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetRenovation()
      {
         if (renovation == null)
            renovation = new System.Collections.ArrayList();
         return renovation;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetRenovation(System.Collections.ArrayList newRenovation)
      {
         RemoveAllRenovation();
         foreach (Renovation oRenovation in newRenovation)
            AddRenovation(oRenovation);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddRenovation(Renovation newRenovation)
      {
         if (newRenovation == null)
            return;
         if (this.renovation == null)
            this.renovation = new System.Collections.ArrayList();
         if (!this.renovation.Contains(newRenovation))
            this.renovation.Add(newRenovation);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveRenovation(Renovation oldRenovation)
      {
         if (oldRenovation == null)
            return;
         if (this.renovation != null)
            if (this.renovation.Contains(oldRenovation))
               this.renovation.Remove(oldRenovation);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllRenovation()
      {
         if (renovation != null)
            renovation.Clear();
      }

    }
}