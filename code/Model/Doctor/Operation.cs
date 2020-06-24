

using Model.Director;
using Model.PatientSecretary;
using Model.Users;
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
        public long Id;
        public User Patient;

        public Operation( long id, User patient, Users.Doctor doctor, string description, Period period, Room room)
        {
            Doctor = doctor;
            Patient = patient;
            Description = description;
            Period = period;
            Room = room;
            Id = id;
        }

        public Operation( User patient,Users.Doctor doctor, string description, Period period, Room room)
        {
            Patient = patient;
            Doctor = doctor;
            Description = description;
            Period = period;
            Room = room;
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