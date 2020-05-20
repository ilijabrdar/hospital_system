/***********************************************************************
 * Module:  Referral.cs
 * Author:  Asus
 * Purpose: Definition of the Class Doctor.Referral
 ***********************************************************************/

using Model.PatientSecretary;
using System;

namespace Model.Doctor
{
   public class Referral
   {
      private DateTime Date;
      private DateTime ExpirationDate;
      
      private Model.Users.Doctor doctor;
      private Examination[] examination;
   
   }
}