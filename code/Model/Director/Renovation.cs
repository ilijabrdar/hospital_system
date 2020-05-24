/***********************************************************************
 * Module:  Renovation.cs
 * Author:  david
 * Purpose: Definition of the Class Director.Renovation
 ***********************************************************************/

using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;

namespace Model.Director
{
   public class Renovation : IIdentifiable<long>
   {
      public string  Description { get; set; }
      public RenovationStatus Status { get; set; }
      
      public Period Period { get; set; }

      public List<Room> Rooms { get; set; }
        
        public long Id { get; set; }
        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public Renovation(long id, RenovationStatus status, Period period, string description, List<Room> rooms)
        {
            Id = id;
            Status = status;
            Period = period;
            Description = description;
            Rooms = rooms;
        }

        public Renovation(RenovationStatus status, Period period, string description, List<Room> rooms)
        {
            Status = status;
            Period = period;
            Description = description;
            Rooms = rooms;
        }

        public Renovation(long id)
        {
            Id = id;
        }
    }
}