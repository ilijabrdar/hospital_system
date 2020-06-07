/***********************************************************************
 * Module:  DoctorGradeService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.DoctorGradeService
 ***********************************************************************/

using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Controller
{
    public class DoctorGradeController :   IDoctorGradeController
    {
        private IDoctorGradeService _service;

        public DoctorGradeController(IDoctorGradeService service)
        {
            _service = service;
        }

        public void Delete(DoctorGrade entity)
        {
            _service.Delete(entity);
        }

        public void Edit(DoctorGrade entity)
        {
            _service.Edit(entity);
        }

        public DoctorGrade Get(long id)
        {
            return _service.Get(id);
        }

        public IEnumerable<DoctorGrade> GetAll()
        {
            return _service.GetAll();
        }

        public double GetAverageGrade(Doctor doctor, List<int> grades)
        {
            throw new NotImplementedException();
        }

        public List<string> GetQuestions()
        {
            throw new NotImplementedException();
        }

        public DoctorGrade Save(DoctorGrade entity)
        {
            return _service.Save(entity);
        }
    }
}