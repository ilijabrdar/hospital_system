/***********************************************************************
 * Module:  Hospitalization.cs
 * Author:  Zorana
 * Purpose: Definition of the Class Doctor.Hospitalization
 ***********************************************************************/

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
        public PatientFile PatientFile;
        public Room Room;

        public Hospitalization(long id, Period period, PatientFile patientFile, Room room)
        {
            Id = id;
            this.Period = period;
            this.PatientFile = patientFile;
            this.Room = room;
        }

        public Hospitalization(long id)
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