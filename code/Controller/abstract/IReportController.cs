using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Model.Dto;
using Model.Director;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;

namespace bolnica.Controller
{
    public interface IReportController
    {
        DoctorReportDTO GenerateAnamnesisPrescriptionReport(Examination examination);

        RoomOccupationReportDTO GenerateRoomOccupationReport(Room room, Period period);

        SecretaryReportDTO GenerateDoctorOccupationReport(Doctor doctor, Period period);

        List<Therapy> GenerateTherapyTimetableReport(PatientFile patientFile);
    }

}
