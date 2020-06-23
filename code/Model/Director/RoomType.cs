
using Repository;
using System;

namespace Model.Director
{
   public class RoomType : IIdentifiable<long>
   {
        public string Name { get; set; }

        public RoomType(string name)
        {
            
            Name = name;
        }

        public RoomType(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public RoomType(long id)
        {
            Id = id;
        }

        public long Id { get; set; }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
      
   
   }
}