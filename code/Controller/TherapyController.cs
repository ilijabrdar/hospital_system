/***********************************************************************
 * Module:  TherapyService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.TherapyService
 ***********************************************************************/

using Model.PatientSecretary;
using System;

namespace Controller
{
   public class TherapyController
   {
      public Therapy CreateTherapy(Therapy therapy, Examination examination)
      {
         // TODO: implement
         return null;
      }
      
      public Therapy CreateCurrentTherapy(PatientFile patientFile)
      {
         // TODO: implement
         return null;
      }
   
      private Service.IService _service;
   
   }
}