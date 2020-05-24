/***********************************************************************
 * Module:  Specialty.cs
 * Author:  Asus
 * Purpose: Definition of the Class Doctor.Specialty
 ***********************************************************************/

using Repository;
using System;

namespace Model.Doctor
{
   public class Specialty : IIdentifiable<long>
    {
      public String Name { get; set; }
      public long Id { get; set; }
        
      public Specialty (long id, String name)
        {
            this.Name = name;
            this.Id = id;
        }
    public Specialty(long id)
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