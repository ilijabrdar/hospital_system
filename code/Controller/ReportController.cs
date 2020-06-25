using bolnica.Model.Dto;
using bolnica.Service;
using Model.Director;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Controller
{
   public class ReportController
   {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        public DoctorReportDTO GenerateAnamnesisPrescriptionReport(PatientFile patientFile)
      {
         // TODO: implement
         return null;
      }
      
      public RoomOccupationReportDTO GenerateRoomOccupationReport(Room room, Period period)
      {
            return _service.GenerateRoomOccupationReport(room, period);
      }
      
      public SecretaryReportDTO GenerateDoctorOccupationReport(Doctor doctor, Period period)
      {
         // TODO: implement
         return null;
      }
      
      public List<Therapy> GenerateTherapyTimetableReport(PatientFile patientFile)
      {
            return _service.GenerateTherapyTimetableReport(patientFile);
      }
   
   }
}