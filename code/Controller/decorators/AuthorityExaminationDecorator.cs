using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;

namespace bolnica.Controller.decorators
{
    public class AuthorityExaminationDecorator : IExaminationController
    {
        private IExaminationController ExaminationController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityExaminationDecorator(IExaminationController examinationController, string role)
        {
            ExaminationController = examinationController;
            Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<String>() { "Doctor", "Patient", "Secretary" };
            AuthorizedUsers["Edit"] = new List<String>() { "Secretary" };
            AuthorizedUsers["Get"] = new List<String>() { "Doctor", "Patient", "Secretary" };
            AuthorizedUsers["GetAll"] = new List<String>() { "Doctor", "Patient", "Secretary" };
            AuthorizedUsers["GetExaminationsByFilter"] = new List<String>() { "Secretary" };
            AuthorizedUsers["GetFinishedxaminationsByUser"] = new List<String>() { "Doctor" };
            AuthorizedUsers["GetUpcomingExaminationsByUser"] = new List<String>() { "Patient", "Doctor", "Director" };
            AuthorizedUsers["Save"] = new List<String>() { "Patient", "Secretary", "Doctor" };
            AuthorizedUsers["SaveFinishedExamination"] = new List<String>() { "Doctor" };
            AuthorizedUsers["StartUpcomingExamination"] = new List<String>() { "Doctor" };
        }

        public void Delete(Examination entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(x => x == Role) != null)
                ExaminationController.Delete(entity);
        }

        public void Edit(Examination entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(x => x == Role) != null)
                ExaminationController.Edit(entity);
        }

        public Examination Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.Get(id);
            else
                return null;
        }

        public IEnumerable<Examination> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.GetAll();
            else
                return null;
        }

        public List<Examination> GetExaminationsByFilter(ExaminationDTO examinationDTO, bool upcomingOnly)
        {
            if (AuthorizedUsers["GetExaminationsByFilter"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.GetExaminationsByFilter(examinationDTO, upcomingOnly);
            else
                return null;
        }

        public List<Examination> GetFinishedxaminationsByUser(User user)
        {
            if (AuthorizedUsers["GetFinishedxaminationsByUser"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.GetFinishedxaminationsByUser(user);
            else
                return null;
        }

        public List<Examination> GetUpcomingExaminationsByUser(User user)
        {
            if (AuthorizedUsers["GetUpcomingExaminationsByUser"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.GetUpcomingExaminationsByUser(user);
            else
                return null;
        }

        public Examination Save(Examination entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.Save(entity);
            else
                return null;
        }

        public Examination SaveFinishedExamination(Examination examination)
        {
            if (AuthorizedUsers["SaveFinishedExamination"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.SaveFinishedExamination(examination);
            else
                return null;
        }

        public Examination StartUpcomingExamination(Examination examination)
        {
            if (AuthorizedUsers["StartUpcomingExamination"].SingleOrDefault(x => x == Role) != null)
                return ExaminationController.StartUpcomingExamination(examination);
            else
                return null;
        }
    }
}
