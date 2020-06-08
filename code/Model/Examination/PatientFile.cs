

using Model.Doctor;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Model.PatientSecretary
{
   public class PatientFile : IIdentifiable<long>
    {
      private List<Hospitalization> Hospitalization;
      private List<Operation> Operation;
      public Person Person { get; set; }
      private List<Examination> Examination;
      private List<Allergy> Allergy;
        public long Id;

        public PatientFile(long id)
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