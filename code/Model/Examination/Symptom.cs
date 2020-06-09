

using Repository;
using System;

namespace Model.PatientSecretary
{
   public class Symptom : IIdentifiable<long>
    {
      public String Name;
      public long Id;

        public Symptom(string name)
        {
            Name = name;
        }

        public Symptom(long id)
        {
            Id = id;
        }

        public Symptom(long id, string name)
        {
            Name = name;
            Id = id;
        }

        public long GetId()
        {
            return Id;
        }

        public void SetId(long id)
        {
            this.Id = id;
        }
    }
}