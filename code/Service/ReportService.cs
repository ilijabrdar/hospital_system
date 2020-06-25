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
using System.Collections.Generic;

namespace Service
{
   public class ReportService : IReportService
   {
        public IExaminationService _examinationService { get; set; }
        public IRenovationService _renovationService { get; set; }
        public IHospitalizationService _hospitalizationService { get; set; }
        public IOperationService _operationService { get; set; }

        public ReportService(IExaminationService examinationService, IRenovationService renovationService, IHospitalizationService hospitalizationService, IOperationService operationService)
        {
            _examinationService = examinationService;
            _renovationService = renovationService;
            _hospitalizationService = hospitalizationService;
            _operationService = operationService;
        }

        public DoctorReportDTO GenerateAnamnesisPrescriptionReport(PatientFile patientFile)
      {
         // TODO: implement
         return null;
      }
      
        //renovations, operations, examinations, equipment inventory, hospitalizations
      public String GenerateRoomOccupationReport()  //arguments: Room room, Period period
      {
            // TODO: implement
            List<Examination> examinations = new List<Examination>();

            foreach (Examination examination in _examinationService.GetAll())
            {

            }


         return null;
      }
      
      public SecretaryReportDTO GenerateDoctorOccupationReport(Doctor doctor, Period period)
      {
            return null; 
      }
      
      public List<Therapy> GenerateTherapyTimetableReport(PatientFile patientFile)
        {
            List<Therapy> ret = new List<Therapy>();
            foreach (Examination examination in patientFile.Examination)
            {
                if (validateDates(examination.Therapy))
                    ret.Add(examination.Therapy);
            }
            return ret;
        }

        private bool validateDates(Therapy therapy)
        {
            if (DateTime.Compare(DateTime.Now.Date, therapy.Period.StartDate.Date) >= 0 && DateTime.Compare(DateTime.Now.Date, therapy.Period.EndDate.Date) <= 0)
                return true;

            return false;
        }

    }
}