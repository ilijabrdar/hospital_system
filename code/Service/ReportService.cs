/***********************************************************************
 * Module:  ReportService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ReportService
 ***********************************************************************/

using bolnica.Service;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using System;

namespace Service
{
   public class ReportService : IReportService
   {
        IExaminationService _examinationService;

        public ReportService(IExaminationService examinationService)
        {
            _examinationService = examinationService;
        }

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
            return null; 
      }
      
      public Therapy GenerateTherapyTimetableReport(PatientFile patientFile)
      {
         // TODO: implement
         return null;
      }
   
   }
}