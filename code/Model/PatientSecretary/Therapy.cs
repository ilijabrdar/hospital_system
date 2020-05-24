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
      private String Note;
      private DateTime BeginDate;
      private DateTime EndDate;
      private int Amount;
      private int Span;

        public Therapy(long id, string note, DateTime beginDate, DateTime endDate, int amount, int span)
        {
            Id = id;
            Note = note;
            BeginDate = beginDate;
            EndDate = endDate;
            Amount = amount;
            Span = span;

        }

        public Therapy(long id)
        {
            Id = id;
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