using Controller;
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
        Examination StartScheduledExamination(Examination examination);
        Examination FinishExamination(Examination examination);
        Examination[] GetSheduledUserExaminations(User user);
        Examination[] GetExaminationsByUser(User user);
    }
}
