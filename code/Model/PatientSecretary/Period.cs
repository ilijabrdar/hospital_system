/***********************************************************************
 * Module:  Period.cs
 * Author:  david
 * Purpose: Definition of the Class PatientSecretary.Period
 ***********************************************************************/

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

   
   }
}