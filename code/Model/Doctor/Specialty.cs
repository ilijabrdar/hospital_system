

using Repository;
using System;

namespace Model.Doctor
{
   public class Speciality : IIdentifiable<long>
    {
        public String Name;
        public long Id;

        public Speciality(string name)
        {
            Name = name;
        }

        public Speciality (long id, String name)
        {
            this.Name = name;
            this.Id = id;
        }
    public Speciality(long id)
        {
            this.Id = id;
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