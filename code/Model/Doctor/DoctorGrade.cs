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

        public DoctorGrade(long id)
        {
            this.Id = id;
        }
        public long GetId()
        {
            throw new NotImplementedException();
        }

        public void SetId(long id)
        {
            throw new NotImplementedException();
        }
    }
}