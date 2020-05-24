/***********************************************************************
 * Module:  BusinessDay.cs
 * Author:  Zorana
 * Purpose: Definition of the Class Users.BusinessDay
 ***********************************************************************/

using Model.Director;
using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;

namespace Model.Users
{
   public class BusinessDay : IIdentifiable<long>
    {
      public Period Shift { get; set; }

        public long Id;
      
      public List<Period> ScheduledPeriods { get; set; }

      public Doctor doctor { get; set; }

      public Room room { get; set; }

        public BusinessDay(Period shift, Doctor doctor, Room room, List<Period> periods)
        {
            this.Shift = shift;
            this.ScheduledPeriods = periods;
            this.doctor = doctor;
            this.room = room;
        }
        public BusinessDay(long id,Period shift,  Doctor doctor, Room room, List<Period> periods)
        {
            this.Id = id;
            this.Shift = shift;
            this.ScheduledPeriods = periods;
            this.doctor = doctor;
            this.room = room;
        }
        public BusinessDay (long id)
        {
            this.Id = id;
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