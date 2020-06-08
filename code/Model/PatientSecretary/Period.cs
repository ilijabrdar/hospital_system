using System;

namespace Model.PatientSecretary
{
    public class Period
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public Period() {
        }

        public Period(DateTime? startDate,DateTime? endDate)
        {
            StartDate = startDate.Value;
            EndDate = endDate.Value;
        }

      public Period(DateTime start)
        {
            this.StartDate = start;
        }

   
   }
}