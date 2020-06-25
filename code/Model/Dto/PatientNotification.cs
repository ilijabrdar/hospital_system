using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Users;
using Repository;

namespace bolnica.Model.Dto
{
    public class PatientNotification : IIdentifiable<long>
    {
        public long Id { get; set; }
        public Patient Patient { get; set; }
        public Boolean Read { get; set; }
        public String Message { get; set; }

        public PatientNotification(long id, Patient patient, bool read, string message)
        {
            Id = id;
            Patient = patient;
            Read = read;
            Message = message;
        }

        public PatientNotification(Patient patient, bool read, string message)
        {
            Patient = patient;
            Read = read;
            Message = message;
        }
        public PatientNotification(long id)
        {
            Id = id;
        }

        public long GetId()
        {
            return Id; 
        }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}
