
using System;

namespace Model.PatientSecretary
{
   public class Period
   {
      public DateTime StartDate { get; set; }
      public DateTime EndDate { get; set; }

      public Period(DateTime start)
        {
            this.StartDate = start;
        }
      public Period(DateTime start, DateTime end)
      {
          this.StartDate = start;
          this.EndDate = end;
      }

      public Period() { }
   
   }
}