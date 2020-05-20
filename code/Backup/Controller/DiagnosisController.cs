/***********************************************************************
 * Module:  DiagnosisService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DiagnosisService
 ***********************************************************************/

using System;

namespace Controller
{
   public class DiagnosisController
   {
      public Diagnosis CreateDiagnosis(Examination examination, Diagnosis diagnosis)
      {
         // TODO: implement
         return null;
      }
      
      public Diagnosis CreateDiagnosisBasedOnSymptoms(Symptom symptom, Examination examination)
      {
         // TODO: implement
         return null;
      }
   
      private Service.IService _service;
   
   }
}