/***********************************************************************
 * Module:  Operation.cs
 * Author:  Zorana
 * Purpose: Definition of the Class Doctor.Operation
 ***********************************************************************/

using Model.Director;
using Model.PatientSecretary;
using Repository;
using System;

namespace Model.Doctor
{
   public class Operation : IIdentifiable<long>
    {
      public Model.Users.Doctor doctor;

        public String Description;

        public Period period;
        public Room room;
        public PatientFile patientFile;
        public long Id;

        public Operation( long id,Users.Doctor doctor, string description, Period period, Room room, PatientFile patientFile)
        {
            this.doctor = doctor;
            Description = description;
            this.period = period;
            this.room = room;
            this.patientFile = patientFile;
            this.Id = id;
        }

        public Operation(Users.Doctor doctor, string description, Period period, Room room, PatientFile patientFile)
        {
            this.doctor = doctor;
            Description = description;
            this.period = period;
            this.room = room;
            this.patientFile = patientFile;
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