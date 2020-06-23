using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using System;

namespace Controller
{
   public class ReportController
   {
      public DoctorReportDTO GenerateAnamnesisPrescriptionReport(PatientFile patientFile)
      {
         // TODO: implement
         return null;
      }
      
      public String GenerateRoomOccupationReport()
      {
         // TODO: implement
         return null;
      }
      
      public SecretaryReportDTO GenerateDoctorOccupationReport(Doctor doctor, Period period)
      {
         // TODO: implement
         return null;
      }
      
      public Therapy GenerateTherapyTimetableReport(PatientFile patientFile)
      {
         // TODO: implement
         return null;
      }
   
      //private Service.IService _service;
   
   }
}