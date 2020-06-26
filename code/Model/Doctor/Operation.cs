

using Model.Director;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;

namespace Model.Doctor
{
   public class Operation : IIdentifiable<long>
    {
        public Model.Users.Doctor Doctor { get; set; }
        public String Description { get; set; }
        public Period Period { get; set; }
        public Room Room { get; set; }
        public long Id { get; set; }
        public User Patient { get; set; }

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