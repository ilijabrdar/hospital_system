/***********************************************************************
 * Module:  Examination.cs
 * Author:  david
 * Purpose: Definition of the Class PatientSecretary.Examination
 ***********************************************************************/

using Repository;
using System;
using Model.Users;
using bolnica.Service;
using System.Collections.Generic;

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
        public Refferal Refferal;

        public Examination(long id,  Users.Doctor doctor, Period period)
        {
            Id = id;
            Doctor = doctor;
            Period = period;
        }
        public Examination(long id, Users.Doctor doctor, Period period, Diagnosis diagnosis, Anemnesis anemnesis, Therapy therapy, Refferal refferal)
        {
            Id = id;
            Doctor = doctor;
            Period = period;
            Diagnosis = diagnosis;
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
            throw new NotImplementedException();
        }

        public void SetId(long id)
        {
            throw new NotImplementedException();
        }

    }
}