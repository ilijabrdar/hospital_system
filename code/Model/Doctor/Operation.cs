

using Model.Director;
using Model.PatientSecretary;
using Repository;
using System;

namespace Model.Doctor
{
   public class Operation : IIdentifiable<long>
    {
        public Model.Users.Doctor Doctor;
        public String Description;
        public Period Period;
        public Room Room;
        public PatientFile PatientFile;
        public long Id;

        public Operation( long id,Users.Doctor doctor, string description, Period period, Room room, PatientFile patientFile)
        {
            this.Doctor = doctor;
            Description = description;
            this.Period = period;
            this.Room = room;
            this.PatientFile = patientFile;
            this.Id = id;
        }

        public Operation(Users.Doctor doctor, string description, Period period, Room room, PatientFile patientFile)
        {
            this.Doctor = doctor;
            Description = description;
            this.Period = period;
            this.Room = room;
            this.PatientFile = patientFile;
        }

        public Operation(long id)
        {
            Id = id;
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