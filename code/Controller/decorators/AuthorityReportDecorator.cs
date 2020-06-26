using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;

namespace bolnica.Controller.decorators
{
    public class AuthorityReportDecorator : IReportController
    {
        private IReportController ReportController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityReportDecorator(IReportController reportController, string role)
        {
            ReportController = reportController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["GenerateAnamnesisPrescriptionReport"] = new List<String>() { "Doctor"};
            AuthorizedUsers["GenerateDoctorOccupationReport"] = new List<String>() { "Director" };
            AuthorizedUsers["GenerateRoomOccupationReport"] = new List<String>() { "Secretary" };
            AuthorizedUsers["GenerateTherapyTimetableReport"] = new List<String>() { "Patient" };
        }

        public DoctorReportDTO GenerateAnamnesisPrescriptionReport(PatientFile patientFile)
        {
            if (AuthorizedUsers["GenerateAnamnesisPrescriptionReport"].SingleOrDefault(x => x == Role) != null)
                return ReportController.GenerateAnamnesisPrescriptionReport(patientFile);
            else
                return null;
        }

        public SecretaryReportDTO GenerateDoctorOccupationReport(Doctor doctor, Period period)
        {
            if (AuthorizedUsers["GenerateDoctorOccupationReport"].SingleOrDefault(x => x == Role) != null)
                return ReportController.GenerateDoctorOccupationReport(doctor, period);
            else
                return null;
        }

        public string GenerateRoomOccupationReport()
        {
            if (AuthorizedUsers["GenerateRoomOccupationReport"].SingleOrDefault(x => x == Role) != null)
                return ReportController.GenerateRoomOccupationReport();
            else
                return null;
        }

        public List<Therapy> GenerateTherapyTimetableReport(PatientFile patientFile)
        {
            if (AuthorizedUsers["GenerateTherapyTimetableReport"].SingleOrDefault(x => x == Role) != null)
                return ReportController.GenerateTherapyTimetableReport(patientFile);
            else
                return null;
        }
    }
}
