/***********************************************************************
 * Module:  IDoctorGradeRepository.cs
 * Author:  david
 * Purpose: Definition of the Interface Repository.IDoctorGradeRepository
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IDoctorGradeRepository
   {
      List<String> GetQuestions();
   }
}