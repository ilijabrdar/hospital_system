/***********************************************************************
 * Module:  Renovation.cs
 * Author:  david
 * Purpose: Definition of the Class Director.Renovation
 ***********************************************************************/

using System;

namespace Model.Director
{
   public class Renovation
   {
      private String Description;
      private RenovationStatus Status;
      
      private Model.PatientSecretary.Period period;
      private Room[] room;
   
   }
}