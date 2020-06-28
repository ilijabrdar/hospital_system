using Repository;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Model.PatientSecretary
{
   public class Prescription: IIdentifiable<long>
   {
        public long Id;
        public Period Period { get; set; }
        public List<Drug> Drug { get; set; }

        public Prescription() { }
        public Prescription(long id, Period period)
        {
            Id = id;
            Period = period;
        }

        public Prescription(long id, Period period, List<Drug> alternative)
        {
            Period = period;
            Id = id;
            this.Drug = alternative;
        }

        public Prescription(Period period, List<Drug> drug)
        {
            Period = period;
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