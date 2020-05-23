/***********************************************************************
 * Module:  Operation.cs
 * Author:  Zorana
 * Purpose: Definition of the Class Doctor.Operation
 ***********************************************************************/

using System;

namespace Model.Doctor
{
   public class Operation
   {
      public Model.Users.Doctor[] doctor;
   
      private String Description;
      
      private Model.PatientSecretary.Period period;
      private Model.Director.Room room;
      private Model.PatientSecretary.PatientFile patientFile;
      
      
      
      
   
   }
}