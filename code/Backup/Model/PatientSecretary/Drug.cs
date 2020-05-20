/***********************************************************************
 * Module:  Lek.cs
 * Author:  Tamara Kovacevic
 * Purpose: Definition of the Class Pacijent.Lek
 ***********************************************************************/

using System;

namespace Model.PatientSecretary
{
   public class Drug
   {
      private String Name;
      private String Id;
      private int Amount;
      private Boolean Approved = False;
      
      private Ingredient[] ingredient;
      private Drug[] Alternative;
   
   }
}