
using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IDoctorGradeRepository : IRepository<DoctorGrade, long>
   {    
      
      List<String> GetQuestions();
   }
}