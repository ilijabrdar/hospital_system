using Repository;
using System;
using System.Collections.Generic;

namespace Model.PatientSecretary
{
   public class Therapy : IIdentifiable<long>
   {
        public long Id;
        public String Note { get; set; }
        public Period Period { get; set; }
        public List<Drug> Drug { get; set; }

        public Therapy() { }

        public Therapy(long id, Period period,string note, List<Drug> drug) 
        {
            Id = id;
            Note = note;
            Period =period;
            Drug = drug;

        }

        public Therapy(long id,Period period,string note)
        {
            Id = id;
            Note = note;
            Period = period;
        }

        public Therapy(string note, Period period, List<Drug> drug)
        {
            Note = note;
            Period = period;
            Drug = drug;
        }

        public Therapy(long id)
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