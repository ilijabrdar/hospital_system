using Controller;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
    interface IExaminationController : IController<Examination, long>
    {
        Examination StartUpcomingExamination(Examination examination);
        Examination SaveFinishedExamination(Examination examination);
        List<Examination> GetUpcomingExaminationsByUser(User user);
        List<Examination> GetFinishedxaminationsByUser(User user);

       List<Examination> GetExaminationFilter(ExaminationDTO examinationDTO);
    }
}
