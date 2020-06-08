using bolnica.Service;
using Model.Doctor;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{

   public class DoctorGradeService : IDoctorGradeService
   {
   
        private readonly IDoctorGradeRepository _doctorGradeRepository;

        public DoctorGradeService(IDoctorGradeRepository doctorGradeRepository)
        {
            _doctorGradeRepository = doctorGradeRepository;
        }

        public void Delete(DoctorGrade entity)
        {
           _doctorGradeRepository.Delete(entity);
        }

        public void Edit(DoctorGrade entity)
        {
            _doctorGradeRepository.Edit(entity);
        }

        public DoctorGrade Get(long id)
        {
            return _doctorGradeRepository.Get(id);
        }

        public IEnumerable<DoctorGrade> GetAll()
        {
            return _doctorGradeRepository.GetAll();
        }

        public double GetAverage(Doctor doctor)
        {
            Dictionary<String, double> doctorGrades = doctor.doctorGrade.GradesForEachQuestions;
            double retVal = 0;
            foreach(var value in doctorGrades.Values)
            {
                retVal += value;
            }
            retVal /= doctorGrades.Count;

            return retVal;
            
        }

        public List<string> GetQuestions()
        {
            return _doctorGradeRepository.GetQuestions();
        }

        public DoctorGrade Save(DoctorGrade entity)
        {
            return _doctorGradeRepository.Save(entity);
        }
    }
}