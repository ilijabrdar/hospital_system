/***********************************************************************
 * Module:  Therapy.cs
 * Author:  david
 * Purpose: Definition of the Class Model.PatientSecretary.Therapy
 ***********************************************************************/

using Repository;
using System;

namespace Model.PatientSecretary
{
   public class Therapy : IIdentifiable<long>
   {
        public long Id;
        public String Note;
        public Period Period;
        public int DrugDosage;

        public Therapy(long id, Period period, int drugDosage, string note) 
        {
            Id = id;
            Note = note;
            Period =period;
            DrugDosage = drugDosage;
        }

        public Therapy(string note, Period period, int drugDosage)
        {
            Note = note;
            Period = period;
            DrugDosage = drugDosage;
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