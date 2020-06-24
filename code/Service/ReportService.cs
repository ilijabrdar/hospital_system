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