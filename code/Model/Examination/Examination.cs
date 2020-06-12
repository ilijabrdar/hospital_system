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
        public User User;
        public Model.Users.Doctor Doctor;
        public Period Period;
        public Diagnosis Diagnosis;
        public List<Prescription> Prescription;
        public Anemnesis Anemnesis;
        public Therapy Therapy;
        public Referral Refferal;

        public Examination(long id,  Users.Doctor doctor, Period period)
        {
            Id = id;
            Doctor = doctor;
            Period = period;
        }
        public Examination(long id, Users.Doctor doctor, Period period, Diagnosis diagnosis, Anemnesis anemnesis, Therapy therapy, Referral refferal)
        {
            Id = id;
            Doctor = doctor;
            Period = period;
            Diagnosis = diagnosis;
            Anemnesis = anemnesis;
            Therapy = therapy;
            Refferal = refferal;
        }

        public Examination(User user, Users.Doctor doctor, Period period, Diagnosis diagnosis, List<Prescription> prescription, Anemnesis anemnesis, Therapy therapy, Referral refferal)
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