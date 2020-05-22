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
        Dictionary<Equipment, int> equipment_inventar;

      //private String Id;
      private int EquipmentCounter;
      private String Name;

        
      
      private System.Collections.ArrayList equipment;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetEquipment()
      {
         if (equipment == null)
            equipment = new System.Collections.ArrayList();
         return equipment;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetEquipment(System.Collections.ArrayList newEquipment)
      {
         RemoveAllEquipment();
         foreach (Equipment oEquipment in newEquipment)
            AddEquipment(oEquipment);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddEquipment(Equipment newEquipment)
      {
         if (newEquipment == null)
            return;
         if (this.equipment == null)
            this.equipment = new System.Collections.ArrayList();
         if (!this.equipment.Contains(newEquipment))
            this.equipment.Add(newEquipment);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveEquipment(Equipment oldEquipment)
      {
         if (oldEquipment == null)
            return;
         if (this.equipment != null)
            if (this.equipment.Contains(oldEquipment))
               this.equipment.Remove(oldEquipment);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllEquipment()
      {
         if (equipment != null)
            equipment.Clear();
      }
      private RoomType roomType;
      private System.Collections.ArrayList renovation;
      
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
        public long Id { get; set; }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}