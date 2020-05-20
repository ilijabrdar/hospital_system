/***********************************************************************
 * Module:  Patient.cs
 * Author:  Asus
 * Purpose: Definition of the Class Users.Patient
 ***********************************************************************/

using System;

namespace Model.Users
{
   public class Patient : User
   {
      public PatientFile patientFile;
   
      private String Username;
      private String Password;
      private Object Image;
      private Boolean Guest;
   
   }
}