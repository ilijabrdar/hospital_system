using Repository;
using System;
using Model.Users;
using bolnica.Service;
using System.Collections.Generic;
using Model.Doctor;

namespace Model.PatientSecretary
{
   public class Examination : IIdentifiable<long>
   {
        public long Id;
        public User User { get; set; }
        public Model.Users.Doctor Doctor { get; set; }
        public Period Period { get; set; }
        public Diagnosis Diagnosis { get; set; }
        public List<Prescription> Prescription { get; set; }
        public Anemnesis Anemnesis { get; set; }
        public Therapy Therapy { get; set; }
        public Referral Refferal { get; set; }

        public Examination(long id,  Users.Doctor doctor, Period period)
        {
            Id = id;
            Doctor = doctor;
            Period = period;
        }
        public Examination(long id, User user, Users.Doctor doctor, Period period, Diagnosis diagnosis, Anemnesis anemnesis, Therapy therapy, Referral refferal)
        {
            User = user;
            Id = id;
            Doctor = doctor;
            Period = period;
            Diagnosis = diagnosis;
            Anemnesis = anemnesis;
            Therapy = therapy;
            Refferal = refferal;
        }

        public Examination(long id, User user,Users.Doctor doctor, Period period, Diagnosis diagnosis, Anemnesis anemnesis, Therapy therapy, Referral refferal, List<Prescription> prescription)
        {
            User = user;
            Doctor = doctor;
            Period = period;
            Diagnosis = diagnosis;
            Prescription = prescription;
            Anemnesis = anemnesis;
            Therapy = therapy;
            Refferal = refferal;
        }

        public Examination(long id)
        {
            Id = id;
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