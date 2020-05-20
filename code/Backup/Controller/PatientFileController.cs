/***********************************************************************
 * Module:  PatientFileService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.PatientFileService
 ***********************************************************************/

using System;

namespace Controller
{
   public class PatientFileController : IController
   {
      public PatientFile GetPatientFile(Patient patient)
      {
         // TODO: implement
         return null;
      }
      
      public Examination AddExamination(Examination examination, PatientFile patientFile)
      {
         // TODO: implement
         return null;
      }
      
      public Hospitalization AddHospitalization(Hospitalization hospitalization, PatientFile patientFile)
      {
         // TODO: implement
         return null;
      }
      
      public Operation AddOperation(Operation operation, PatientFile patientFile)
      {
         // TODO: implement
         return null;
      }
      
      public Allergy AddAllergy(Allergy allergy, PatientFile patientFile)
      {
         // TODO: implement
         return null;
      }
      
      public Allergy EditAllergy(PatientFile patientFile, Allergy allergy)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAllergy(PatientFile patientFile, Allergy allergy)
      {
         // TODO: implement
         return null;
      }
   
      private Service.IService _service;
   
   }
}