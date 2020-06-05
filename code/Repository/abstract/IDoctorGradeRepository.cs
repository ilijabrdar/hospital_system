/***********************************************************************
 * Module:  IDoctorGradeRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IDoctorGradeRepository
 ***********************************************************************/

using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IDoctorGradeRepository : IRepository<DoctorGrade,long>
   {
      List<String> GetQuestions();
   }
}