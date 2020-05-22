/***********************************************************************
 * Module:  DoctorGradeService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.DoctorGradeService
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository
{
   public class DoctorGradeRepository : IDoctorGradeRepository
   {
      private readonly String FilePath; 
      

        public List<string> GetQuestions()
        {
            string[] questions = File.ReadAllLines(FilePath);
            List<String> retVal = questions.ToList();
            return retVal;
        }
        
    }
}