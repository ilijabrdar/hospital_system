using bolnica.Controller;
using bolnica.Service;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class ExaminationController : IExaminationController
    {
        private readonly IExaminationService _examinationService;

        public ExaminationController(IExaminationService service)
        {
            _examinationService = service;
        }
        public void Delete(Examination entity)
        {
            _examinationService.Delete(entity); 
        }

        public void Edit(Examination entity)
        {
            _examinationService.Edit(entity);
        }
        public Examination Get(long id)
        {
            return _examinationService.Get(id);
        }

        public IEnumerable<Examination> GetAll()
        {
            return _examinationService.GetAll();
        }
        public Examination Save(Examination entity)
        {
            return _examinationService.Save(entity);
        }

        public List<Examination> GetExaminationFilter(ExaminationDTO examinationDTO)
        {
            return _examinationService.GetExaminationFilter(examinationDTO);

        }

        public List<Examination> GetFinishedxaminationsByUser(User user)
        {
            return _examinationService.GetFinishedxaminationsByUser(user);
        }

        public List<Examination> GetUpcomingExaminationsByUser(User user)
        {
            return _examinationService.GetUpcomingExaminationsByUser(user);
        }

        public Examination SaveFinishedExamination(Examination examination)
        {
            return _examinationService.SaveFinishedExamination(examination);
        }

        public Examination StartUpcomingExamination(Examination examination)
        {
            return _examinationService.StartUpcomingExamination(examination);
        }
    }
}