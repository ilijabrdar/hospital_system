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
        Examination StartScheduledExamination(Examination examination);
        Examination FinishExamination(Examination examination);
        Examination[] GetSheduledUserExaminations(User user);
        Examination[] GetExaminationsByUser(User user);
    }
}
