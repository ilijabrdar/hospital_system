using bolnica.Controller;
using bolnica.Service;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Controller
{
   public class ReportController : IReportController
   {

        IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

      public DoctorReportDTO GenerateAnamnesisPrescriptionReport(Examination examination)
      {
         return _reportService.GenerateAnamnesisPrescriptionReport(examination);
      }
      
      public String GenerateRoomOccupationReport()
      {
         // TODO: implement
         return null;
      }
      
      public SecretaryReportDTO GenerateDoctorOccupationReport(Doctor doctor, Period period)
      {
            return _reportService.GenerateDoctorOccupationReport(doctor, period);
      }
      
      public List<Therapy> GenerateTherapyTimetableReport(PatientFile patientFile)
      {
            return _reportService.GenerateTherapyTimetableReport(patientFile);
      }
   
   }
}