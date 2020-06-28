using Model.Director;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IExaminationService : IService<Examination,long>
    {
        Examination SaveFinishedExamination(Examination examination);
        List<Examination> GetUpcomingExaminationsByUser(User user);
        List<Examination> GetFinishedxaminationsByUser(User user);
        List<Examination> GetExaminationsByFilter(ExaminationDTO examinationDTO, Boolean upcomingOnly);
        IEnumerable<Examination> GetAllPrevious();
        Room getExaminationRoom(Examination examination);
        List<Examination> GetUpcomingExaminationsByRoomAndPeriod(Room room, Period period);
        List<Examination> GetPreviousExaminationsByRoomAndPeriod(Room room, Period period);

    }
}
