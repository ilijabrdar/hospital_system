
using Repository;
using System;

namespace Model.Users
{
    public abstract class Person : IIdentifiable<long>
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Jmbg { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String FullName
        {
            get
            {
                return $"{ FirstName } { LastName }";
            }
        }


        public Address Address { get; set; } 

        public abstract long GetId();


        public abstract void SetId(long id);
       
    }
}