using Repository;
using System;
using System.Collections.Generic;

namespace Model.Doctor
{
   public class DoctorGrade : IIdentifiable<long>
    {
        public Dictionary<String, double> GradesForEachQuestions { get; set; }
        public int numberOfGrades { get; set; }

        public long Id;



        public DoctorGrade(long id, int numberOfGrades)
        {
            numberOfGrades = numberOfGrades;
            Id = id;
        }

        public DoctorGrade( long id, int numberOfGrades, Dictionary<string, double> gradesForEachQuestions)
        {
            GradesForEachQuestions = gradesForEachQuestions;
            numberOfGrades = numberOfGrades;
            Id = id;
        }

        public DoctorGrade(int numberOfGrades, Dictionary<string, double> gradesForEachQuestions)
        {
            numberOfGrades = numberOfGrades;
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