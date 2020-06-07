using Repository;
using System;
using System.Collections.Generic;

namespace Model.Doctor
{
   public class DoctorGrade : IIdentifiable<long>
    {
        public long Id;
        public int NumberOfGrades;
        public Dictionary<String,double> GradesForEachQuestions;



        public DoctorGrade(long id, int numberOfGrades)
        {
            NumberOfGrades = numberOfGrades;
            Id = id;
        }

        public DoctorGrade( long id, int numberOfGrades, Dictionary<string, double> gradesForEachQuestions)
        {
            GradesForEachQuestions = gradesForEachQuestions;
            NumberOfGrades = numberOfGrades;
            Id = id;
        }

        public DoctorGrade(int numberOfGrades, Dictionary<string, double> gradesForEachQuestions)
        {
            NumberOfGrades = numberOfGrades;
            GradesForEachQuestions = gradesForEachQuestions;
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