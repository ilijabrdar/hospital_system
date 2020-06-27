using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace Model.Doctor
{
   public class DoctorGrade : IIdentifiable<long>
    {
        public Dictionary<String, double> GradesForEachQuestions { get; set; }
        public int NumberOfGrades { get; set; }

        public long Id;

        public double AverageGrade
        {
            get
            {
                return GradesForEachQuestions.Values.Sum()/ GradesForEachQuestions.Keys.Count;
            }
            set
            {

            }
        }


        public DoctorGrade() { }
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