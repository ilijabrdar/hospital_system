

using Model.PatientSecretary;
using Repository;
using System;
using System.Drawing;
using System.Security.Authentication.ExtendedProtection.Configuration;

namespace Model.Users
{
   public class Patient : User
    {
      public PatientFile patientFile { get; set; }
      public Boolean Guest = false;
       

        public Patient(long id,String name, String surname, String jmbg, String email, String phone, DateTime birth, Address address, String username, String password, Uri img)
        {
            this.Id = id;
            this.FirstName = name;
            this.LastName = surname;
            this.Jmbg = jmbg;
            this.Email = email;
            this.Phone = phone;
            this.DateOfBirth = birth;
            this.Address = address;
            this.Username = username;
            this.Password = password;
            this.Image = img;
        }
        public Patient(long id, String name, String surname, String jmbg, String email, String phone, DateTime birth, Address address, String username, String password, Uri img, PatientFile patientFile, Boolean guest)
        {
            this.Id = id;
            this.FirstName = name;
            this.LastName = surname;
            this.Jmbg = jmbg;
            this.Email = email;
            this.Phone = phone;
            this.DateOfBirth = birth;
            this.Address = address;
            this.Username = username;
            this.Password = password;
            this.Image = img;
            this.patientFile = patientFile;
            this.Guest = guest;
        }

        public Patient(String name, String surname, String jmbg, String email, String phone, DateTime birth, Boolean guest)
        {
            this.FirstName = name;
            this.LastName = surname;
            this.Jmbg = jmbg;
            this.Email = email;
            this.Phone = phone;
            this.DateOfBirth = birth;
            this.Guest = guest;
        }

        public Patient(long id)
        {
            this.Id = id;
        }

        public Patient(Boolean guest)
        {
            Guest = guest;
        }
        override
        public long GetId()
        {
            return this.Id;
        }

        override
        public void SetId(long id)
        {
            this.Id = id;
        }
    }
}