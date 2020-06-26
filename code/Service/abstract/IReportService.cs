using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;

namespace bolnica.Service
{
    public interface IReportService
    {
        DoctorReportDTO GenerateAnamnesisPrescriptionReport(Examination examination);

        String GenerateRoomOccupationReport();

        SecretaryReportDTO GenerateDoctorOccupationReport(Doctor doctor, Period period);

        List<Therapy> GenerateTherapyTimetableReport(PatientFile patientFile);
    }
}
