using bolnica.Controller;
using bolnica.Service;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using System;

namespace Controller
{
   public class ReportController : IReportController
   {
        IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
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
            return _reportService.GenerateDoctorOccupationReport(doctor, period);
      }
      
      public Therapy GenerateTherapyTimetableReport(PatientFile patientFile)
      {
         // TODO: implement
         return null;
      }
   
      //private Service.IService _service;
   
   }
}