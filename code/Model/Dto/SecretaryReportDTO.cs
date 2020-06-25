using System;
using System.Collections.Generic;
using Model.Doctor;
using Model.PatientSecretary;

namespace Model.Dto
{
   public class SecretaryReportDTO
   {
      public List<Operation> Operations { get; set; }
      public List<Examination> Examinations { get; set; }

        public SecretaryReportDTO()
        {
            Operations = new List<Operation>();
            Examinations = new List<Examination>();
        }
   }
}