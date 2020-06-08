using bolnica.Controller;
using bolnica.Service;
using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Controller
{
<<<<<<< HEAD
    public class DoctorGradeController : IDoctorGradeController
    {
        private readonly IDoctorGradeService _doctorGradeService;

        public DoctorGradeController(IDoctorGradeService doctorGradeService)
        {
            _doctorGradeService = doctorGradeService;
        }

        public void Delete(DoctorGrade entity)
        {
            _doctorGradeService.Delete(entity);

        }

        public void Edit(DoctorGrade entity)
        {
            _doctorGradeService.Edit(entity);
        }

        public DoctorGrade Get(long id)
        {
            return _doctorGradeService.Get(id);
        }

        public IEnumerable<DoctorGrade> GetAll()
        {
            return _doctorGradeService.GetAll();
        }

        public double GetAverage(Doctor doctor)
        {
           return _doctorGradeService.GetAverage(doctor);

        }

        public List<string> GetQuestions()
        {
            throw new NotImplementedException();
        }

        public DoctorGrade Save(DoctorGrade entity)
        {
            return _doctorGradeService.Save(entity);
        }
    }
}