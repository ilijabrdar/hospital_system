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
        Examination StartUpcomingExamination(Examination examination);
        Examination SaveFinishedExamination(Examination examination);
        List<Examination> GetUpcomingExaminationsByUser(User user);
        List<Examination> GetFinishedxaminationsByUser(User user);
      //   List<Examination> GetExaminationFilter(ExaminationDTO examinationDTO);
    }
}
