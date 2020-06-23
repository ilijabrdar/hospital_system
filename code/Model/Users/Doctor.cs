using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;

namespace Model.Users
{
   public class Doctor : User
   {
        public List<BusinessDay> BusinessDay { get; set; }
        public Speciality Specialty { get; set; }
        public DoctorGrade DoctorGrade { get; set; }

        public Doctor(long id, String name, String surname, String jmbg, String email, String phone, DateTime birth, Address address, String username, String password, Uri img,Speciality spec )
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
            this.Specialty = spec;
        }

        public Doctor(long id, String name, String surname, String jmbg, String email, String phone, DateTime birth, Address address, String username, String password, Uri img, Speciality speciality, List<Article> articles, List<BusinessDay> businessDay ,DoctorGrade doctGrade)
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
            this.BusinessDay = businessDay;
            this.Specialty = speciality;
            this.DoctorGrade = doctGrade;
        }

        public Doctor( String name, String surname, String jmbg, String email, String phone, DateTime birth, Address adress, String username, String password, Uri img, Speciality speciality, List<Article> articles, List<BusinessDay> businessDay, DoctorGrade doctGrade)
        {
            this.FirstName = name;
            this.LastName = surname;
            this.Jmbg = jmbg;
            this.Email = email;
            this.Phone = phone;
            this.DateOfBirth = birth;
            this.Address = adress;
            this.Username = username;
            this.Password = password;
            this.Image = img;
            this.BusinessDay = businessDay;
            this.Specialty = speciality;
            this.DoctorGrade = doctGrade;
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