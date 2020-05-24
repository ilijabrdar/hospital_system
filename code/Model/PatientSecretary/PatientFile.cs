/***********************************************************************
 * Module:  PatientFile.cs
 * Author:  david
 * Purpose: Definition of the Class PatientSecretary.PatientFile
 ***********************************************************************/

using Model.Doctor;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Model.PatientSecretary
{
   public class PatientFile : IIdentifiable<long>
    {
      private List<Hospitalization> hospitalization;
      private List<Operation> operation;
      public Person person { get; set; }
      private List<Examination> examination;
      private List<Allergy> allergy;
        public long Id;

        public PatientFile(long id)
        {
            this.Id = id;
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