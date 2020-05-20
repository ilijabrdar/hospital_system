/***********************************************************************
 * Module:  Address.cs
 * Author:  Asus
 * Purpose: Definition of the Class Users.Address
 ***********************************************************************/

using System;

namespace Model.Users
{
   public class Address
   {
      private String Street;
      private int Number;
      private int ApartmentNumber;
      
      private Town town;
      
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
   
   }
}