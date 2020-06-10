

using Model.Doctor;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Model.PatientSecretary
{
   public class PatientFile : IIdentifiable<long>
    {
      public List<Hospitalization> Hospitalization { get; set; }
      public List<Operation> Operation { get; set; }
      public List<Examination> Examination { get; set; }
      public List<Allergy> Allergy { get; set; }

        public long Id;

        public PatientFile(long id)
        {
            this.Id = id;
        }

        public PatientFile(long id, List<Allergy> allergy, List<Hospitalization> hospitalizations, List<Operation> operations, List<Examination> examinations)
        {
            Id = id;
            Hospitalization = hospitalizations;
            Operation = operations;
            Examination = examinations;
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