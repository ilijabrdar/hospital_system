using bolnica.Model.Dto;
using bolnica.Service;
using Model.Director;
using Model.Doctor;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;

namespace Service
{
   public class ReportService : IReportService
   {
        public IExaminationService _examinationService { get; set; }
        public IRenovationService _renovationService { get; set; }
        public IHospitalizationService _hospitalizationService { get; set; }
        public IOperationService _operationService { get; set; }

        [Obsolete]
        public static double ExaminationDuration = Double.Parse(ConfigurationSettings.AppSettings["examinationDuration"]);

        public ReportService(IExaminationService examinationService, IRenovationService renovationService, IHospitalizationService hospitalizationService, IOperationService operationService)
        {
            _examinationService = examinationService;
            _renovationService = renovationService;
            _hospitalizationService = hospitalizationService;
            _operationService = operationService;
        }
        public DoctorReportDTO GenerateAnamnesisPrescriptionReport(Examination examination)
        {
            DoctorReportDTO retVal = new DoctorReportDTO(examination.Prescription, examination.Anemnesis, (Patient)examination.User);
            return retVal;    
        }

        public RoomOccupationReportDTO GenerateRoomOccupationReport(Room room, Period period)  
        {
            RoomOccupationReportDTO report = new RoomOccupationReportDTO();

            report.room = room;
            report.period = period;

            List<Renovation> renovations = new List<Renovation>();
            foreach (Renovation renovation in _renovationService.GetAll())
                if (renovation.Room.RoomCode.Equals(room.RoomCode) && DateTime.Compare(renovation.Period.StartDate.Date, period.StartDate.Date) >= 0 && DateTime.Compare(renovation.Period.EndDate.Date, period.EndDate.Date) <= 0)
                    renovations.Add(renovation);
            report.renovations = renovations;


            List<Examination> examinations = new List<Examination>();
            foreach (Examination examination in _examinationService.GetAll())
                if (DateTime.Compare(examination.Period.StartDate.Date, period.StartDate.Date) >= 0 && DateTime.Compare(examination.Period.EndDate.Date, period.EndDate.Date) <= 0)
                {
                    Room examRoom = _examinationService.getExaminationRoom(examination);
                    if (examRoom.Id == room.Id)
                        examinations.Add(examination);
                }
            report.examinations = examinations;

            List<Examination> previousExam = new List<Examination>();
            foreach (Examination examination in _examinationService.GetAllPrevious())
                if (DateTime.Compare(examination.Period.StartDate.Date, period.StartDate.Date) >= 0 && DateTime.Compare(examination.Period.EndDate.Date, period.EndDate.Date) <= 0)
                {
                    Room examRoom = _examinationService.getExaminationRoom(examination);
                    if (examRoom.Id == room.Id)
                        previousExam.Add(examination);
                }
            report.previousExaminations = previousExam;

            List<Operation> operations = new List<Operation>();
            foreach (Operation operation in _operationService.GetAll())
                if (DateTime.Compare(operation.Period.StartDate.Date, period.StartDate.Date) >= 0 && DateTime.Compare(operation.Period.EndDate.Date, period.EndDate.Date) <= 0 && operation.Room.Id == room.Id)
                    operations.Add(operation);
            report.operations = operations;

            List<Hospitalization> hospitalizations = new List<Hospitalization>();
            foreach (Hospitalization hospitalization in _hospitalizationService.GetAll())
                if (DateTime.Compare(hospitalization.Period.StartDate.Date, period.StartDate.Date) >= 0 && DateTime.Compare(hospitalization.Period.EndDate.Date, period.EndDate.Date) <= 0 && hospitalization.Room.Id == room.Id)
                    hospitalizations.Add(hospitalization);
            report.hospitalizations = hospitalizations;


            return report;
      }

        [Obsolete]
        public SecretaryReportDTO GenerateDoctorOccupationReport(Doctor doctor, Period period)
      {
            List<Examination> upcomingExaminations = _examinationService.GetAll().ToList();
            List<Examination> previousExaminations = _examinationService.GetAllPrevious().ToList();
            List<Operation> operations = _operationService.GetAll().ToList();
            SecretaryReportDTO retVal = new SecretaryReportDTO();

            foreach (Examination examination in previousExaminations)
            {
                if (examination.Doctor.Id == doctor.Id && examination.Period.StartDate >= period.StartDate && examination.Period.StartDate.AddMinutes(ExaminationDuration) <= period.EndDate)
                {
                    retVal.Examinations.Add(examination);
                }
            }

            foreach (Examination examination in upcomingExaminations)
            {
                if(examination.Doctor.Id == doctor.Id && examination.Period.StartDate >= period.StartDate && examination.Period.StartDate.AddMinutes(ExaminationDuration) <= period.EndDate)
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