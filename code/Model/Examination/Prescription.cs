using Repository;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Model.PatientSecretary
{
   public class Prescription: IIdentifiable<long>
   {
      public long Id;
      public Period Period;
      public String Note;
      public List<Drug> Drug;
        public Prescription(long id, Period period, string note)
        {
            Period = period;
            Note = note;
        }

        public Prescription(long id, Period period, string note, List<Drug> alternative)
        {
            Period = period;
            Note = note;
            Id = id;
            this.Drug = alternative;
        }

        public Prescription(Period period, string note, List<Drug> drug)
        {
            Period = period;
            Note = note;
            Drug = drug;
        }

        public Prescription(long id)
        {
            Id = id;
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