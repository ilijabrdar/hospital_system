/***********************************************************************
 * Module:  ReportService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ReportService
 ***********************************************************************/

using System;

namespace Controller
{
   public class ReportController
   {
      public DoctorReport GenerateAnamnesisPrescriptionReport(PatientFile patientFile)
      {
         // TODO: implement
         return null;
      }
      
      public String GenerateRoomOccupationReport()
      {
         // TODO: implement
         return null;
      }
      
      public SecretaryReport GenerateDoctorOccupationReport(Doctor doctor, Period period)
      {
         // TODO: implement
         return null;
      }
      
      public Therapy GenerateTherapyTimetableReport(PatientFIle patientFile)
      {
         // TODO: implement
         return null;
      }
   
      private Service.IService _service;
   
   }
}