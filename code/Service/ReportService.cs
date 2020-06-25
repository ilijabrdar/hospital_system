using bolnica.Service;
using Model.Doctor;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
   public class ReportService : IReportService
   {
        IExaminationService _examinationService;
        IOperationService _operationService;

        public ReportService(IExaminationService examinationService, IOperationService operationService)
        {
            _examinationService = examinationService;
            _operationService = operationService;
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
            List<Examination> upcomingExaminations = _examinationService.GetAll().ToList();
            List<Examination> previousExaminations = _examinationService.GetAllPrevious().ToList();
            List<Operation> operations = _operationService.GetAll().ToList();
            SecretaryReportDTO retVal = new SecretaryReportDTO();

            foreach (Examination examination in previousExaminations)
            {
                if (examination.Doctor.Id == doctor.Id && examination.Period.StartDate >= period.StartDate && examination.Period.EndDate <= period.EndDate)
                {
                    retVal.Examinations.Add(examination);
                }
            }

            foreach (Examination examination in upcomingExaminations)
            {
                if(examination.Doctor.Id == doctor.Id && examination.Period.StartDate >= period.StartDate && examination.Period.EndDate <= period.EndDate)
                {
                    retVal.Examinations.Add(examination);        
                }
            }

            foreach (Operation operation in operations)
            {
                if (operation.Doctor.Id == doctor.Id && operation.Period.StartDate >= period.StartDate && operation.Period.EndDate <= period.EndDate)
                {
                    retVal.Operations.Add(operation);
                }
            }

            return retVal; 
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