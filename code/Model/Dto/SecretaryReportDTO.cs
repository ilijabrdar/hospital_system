/***********************************************************************
 * Module:  SecretaryReport.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.SecretaryReport
 ***********************************************************************/

using System;

namespace Model.Dto
{
   public class SecretaryReportDTO
   {
      private Model.Users.Doctor doctor;
      private Model.PatientSecretary.Period period;
      private Model.Doctor.Operation operation;
      private Model.PatientSecretary.Examination examination;
   
   }
}