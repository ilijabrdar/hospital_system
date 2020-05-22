using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
    public class RoomCSVConverter : ICSVConverter<Room>
    {
        private readonly string _delimiter;

        public RoomCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public Room ConvertCSVFormatToEntity(string roomCSV)
        {
            string[] tokens = roomCSV.Split(_delimiter.ToCharArray());
            //return new Room(
            //    long.Parse(tokens[0]),
            //    tokens[1]);

            return null;
        }

        public string ConvertEntityToCSVFormat(Room entity)
        {
            throw new NotImplementedException();
        }
    }
}
