using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Drawing.Printing;

namespace bolnica.Service
{
    public class Refferal : IIdentifiable<long>
    {
        public long Id;
        private DateTime Date;
        private DateTime ExpirationDate;
        private Model.Users.Doctor Doctor;
        private Examination examination;

        public Refferal(long id, DateTime date, DateTime expirationDate, Doctor doctor, Examination examination)
        {
            Id = id;
            Date = date;
            ExpirationDate = expirationDate;
            Doctor = doctor;
            this.examination = examination;
        }

        public Refferal(long id)
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