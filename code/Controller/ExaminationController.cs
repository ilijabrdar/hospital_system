using bolnica.Controller;
using bolnica.Service;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class ExaminationController : IExaminationController
    {
        private IExaminationService _service;

        public ExaminationController(IExaminationService service)
        {
            _service = service;
        }
        public void Delete(Examination entity)
        {
            _service.Delete(entity); 
        }

        public void Edit(Examination entity)
        {
            _service.Edit(entity);
        }
        public Examination Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Examination> GetAll()
        {
            return _service.GetAll();
        }


        public Examination Save(Examination entity)
        {
            return _service.Save(entity);
        }

        List<Examination> IExaminationController.GetFinishedxaminationsByUser(User user)
        {
            throw new NotImplementedException();
        }

        List<Examination> IExaminationController.GetUpcomingExaminationsByUser(User user)
        {
            throw new NotImplementedException();
        }

        Examination IController<Examination, long>.Save(Examination entity)
        {
            throw new NotImplementedException();
        }

        Examination IExaminationController.SaveFinishedExamination(Examination examination)
        {
            throw new NotImplementedException();
        }

        Examination IExaminationController.StartUpcomingExamination(Examination examination)
        {
            throw new NotImplementedException();
        }
    }
}