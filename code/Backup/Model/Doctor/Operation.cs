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
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Model.PatientSecretary.PatientFile GetPatientFile()
      {
         return patientFile;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newPatientFile</param>
      public void SetPatientFile(Model.PatientSecretary.PatientFile newPatientFile)
      {
         if (this.patientFile != newPatientFile)
         {
            if (this.patientFile != null)
            {
               Model.PatientSecretary.PatientFile oldPatientFile = this.patientFile;
               this.patientFile = null;
               oldPatientFile.RemoveOperation(this);
            }
            if (newPatientFile != null)
            {
               this.patientFile = newPatientFile;
               this.patientFile.AddOperation(this);
            }
         }
      }
   
   }
}