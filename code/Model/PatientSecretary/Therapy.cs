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
        public DateTime BeginDate;
        public DateTime EndDate;
        public int DrugDosage;

        public Therapy(long id, DateTime beginDate, DateTime endDate, int drugDosage, string note) 
        {
            Id = id;
            Note = note;
            BeginDate = beginDate;
            EndDate = endDate;
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