/***********************************************************************
 * Module:  Room.cs
 * Author:  david
 * Purpose: Definition of the Class Director.Room
 ***********************************************************************/

using Repository;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Model.Director
{
   public class Room : IIdentifiable<long>
   {
        public Dictionary<Equipment, int> Equipment_inventory { get; set; }

        public string RoomCode { get; set; }
        

        public long Id { get; set; }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;

        public RoomType RoomType { get; set; }

        public Room(string roomCode, RoomType roomType, Dictionary<Equipment, int> equipment_inventory)
        {
            Equipment_inventory = equipment_inventory;
            RoomCode = roomCode;

            this.RoomType = roomType;
        }




        public Room(long id, string roomCode, RoomType roomType, Dictionary<Equipment, int> equipment_inventory)
        {
            Equipment_inventory = equipment_inventory;
            RoomCode = roomCode;

            Id = id;
            this.RoomType = roomType;
        }

        public Room(long id)
        {
            Id = id;
        }


    }
}