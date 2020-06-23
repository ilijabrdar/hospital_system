using Model.Director;
using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;

namespace Model.Doctor
{
   public class Hospitalization : IIdentifiable<long>
    {
        public long Id;
        public Period Period;
        public Room Room;
        //TODO description

        public Hospitalization(long id, Period period, Room room)
        {
            Id = id;
            this.Period = period;
            this.Room = room;
        }

        public Hospitalization(Period period, Room room)
        {
            Period = period;
            Room = room;
        }

        public Hospitalization(long id)
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