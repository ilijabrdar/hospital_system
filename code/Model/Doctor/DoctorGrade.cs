using Repository;
using System;
using System.Collections.Generic;

namespace Model.Doctor
{
   public class DoctorGrade : IIdentifiable<long>
    {
        public Dictionary<String,double> GradesForEachQuestions;
        public int NumberOfGrades;
        public long Id;

        public DoctorGrade(long id, int numberOfGrades)
        {
            NumberOfGrades = numberOfGrades;
            Id = id;
        }

        public DoctorGrade(Dictionary<string, double> gradesForEachQuestions, int numberOfGrades, long id)
        {
            GradesForEachQuestions = gradesForEachQuestions;
            NumberOfGrades = numberOfGrades;
            Id = id;
        }

        public DoctorGrade(long id)
        {
            this.Id = id;
        }

        public long GetId()
        {
            return this.Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }
    }
}