using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;

namespace Model.Users
{
   public class Doctor : User
   {
        public List<Article> articles { get; set; } 
        public List<BusinessDay> businessDay { get; set; }
        public Specialty specialty { get; set; }
        public DoctorGrade doctorGrade { get; set; }
        public Doctor(long id, String name, String surname, String jmbg, String email, String phone, DateTime birth, Address address, String username, String password, Image img,Specialty spec )
        {
            this.Id = id;
            this.FirstName = name;
            this.LastName = surname;
            this.Jmbg = jmbg;
            this.Email = email;
            this.Phone = phone;
            this.DateOfBirth = birth;
            this.address = address;
            this.Username = username;
            this.Password = password;
            this.Image = img;
            this.specialty = spec;
        }
        public Doctor(long id, String name, String surname, String jmbg, String email, String phone, DateTime birth, Address address, String username, String password, Image img, Specialty speciality, List<Article> articles, List<BusinessDay> businessDay ,DoctorGrade doctGrade)
        {
            this.Id = id;
            this.FirstName = name;
            this.LastName = surname;
            this.Jmbg = jmbg;
            this.Email = email;
            this.Phone = phone;
            this.DateOfBirth = birth;
            this.address = address;
            this.Username = username;
            this.Password = password;
            this.Image = img;
            this.articles = articles;
            this.businessDay = businessDay;
            this.specialty = speciality;
            this.doctorGrade = doctGrade;
        }
        public Doctor(long id)
        {
            this.Id = id;
        }

        public override long GetId()
        {
          return this.Id;
        }

        public override void SetId(long id)
        {
            this.Id = id;
        }

    
   
   }
}