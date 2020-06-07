

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

        private readonly IDoctorGradeRepository _repository;

        public DoctorGradeService(IDoctorGradeRepository repository)
        {
            _repository = repository;
        }

        public void Delete(DoctorGrade entity)
        {
            _repository.Delete(entity);
        }

        public void Edit(DoctorGrade entity)
        {
            _repository.Edit(entity);
        }

        public DoctorGrade Get(long id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<DoctorGrade> GetAll()
        {
            return _repository.GetAll();
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
            return _repository.Save(entity);
        }
    }
}