/***********************************************************************
 * Module:  PatientService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.PatientService
 ***********************************************************************/

using System;

namespace Service
{
   public class PatientService : IService
   {
      public Patient ClaimAccount(String jmbg)
      {
         // TODO: implement
         return null;
      }
   
      private Repository.IPatientRepository _patientRepository;
   
   }
}