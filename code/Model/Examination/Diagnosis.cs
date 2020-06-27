using Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Model.PatientSecretary
{
   public class Diagnosis : IIdentifiable<long>
   {
        public long Id { get; set; }
        public string Name { get; set; }

        public Diagnosis() { }
        public Diagnosis(long id)
        {
            Id = id;
        }

        public Diagnosis(long id, string name) : this(id)
        {
            Name = name;
        }

        public Diagnosis(string name)
        {
            Name = name;
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