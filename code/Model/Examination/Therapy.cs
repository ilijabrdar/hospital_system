using Repository;
using System;
using System.Collections.Generic;

namespace Model.PatientSecretary
{
   public class Therapy : IIdentifiable<long>
   {
        public long Id;
        public String Note;
        public Period Period;
        public double DrugDosage;
        public List<Drug> Drug;

        public Therapy(long id, Period period, double drugDosage, string note, List<Drug> drug) 
        {
            Id = id;
            Note = note;
            Period =period;
            DrugDosage = drugDosage;
            Drug = drug;

        }

        public Therapy(long id,Period period, double drugDosage, string note)
        {
            Id = id;
            Note = note;
            Period = period;
            DrugDosage = drugDosage;
        }

        public Therapy(string note, Period period, double drugDosage, List<Drug> drug)
        {
            Note = note;
            Period = period;
            DrugDosage = drugDosage;
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