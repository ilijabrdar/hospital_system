/***********************************************************************
 * Module:  ExaminationService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ExaminationService
 ***********************************************************************/

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

        public Examination FinishExamination(Examination examination)
        {
            throw new NotImplementedException();
        }

        public Examination Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<Examination> GetAll()
        {
            return _service.GetAll();
        }

        public Examination[] GetExaminationsByUser(User user)
        {
            throw new NotImplementedException();
        }

        public Examination[] GetSheduledUserExaminations(User user)
        {
            throw new NotImplementedException();
        }

        public Examination Save(Examination entity)
        {
            return _service.Save(entity);
        }

        public Examination StartScheduledExamination(Examination examination)
        {
            throw new NotImplementedException();
        }
    }
}