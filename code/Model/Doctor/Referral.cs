

using Model.PatientSecretary;
using Repository;
using System;

namespace Model.Doctor
{
   public class Referral : IIdentifiable<long>
   {

        public long Id;
        public Period Period;
        public Model.Users.Doctor Doctor;

        public Referral() { }

        public Referral(long id)
        {
            Id = id;
        }

        public Referral(long id,Period period, Users.Doctor doctor)
        {
            Period = period;
            Doctor = doctor;
            Id = id;
        }

        public Referral(Period period, Users.Doctor doctor)
        {
            Period = period;
            Doctor = doctor;
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