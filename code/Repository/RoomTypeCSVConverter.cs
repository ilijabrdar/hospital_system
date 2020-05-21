using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
    public class RoomTypeCSVConverter : ICSVConverter<RoomType>
    {
        private readonly string _delimiter;
        
        public RoomTypeCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public RoomType ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new RoomType(
                long.Parse(tokens[0]),
                tokens[1]);
                
        }

        public string ConvertEntityToCSVFormat(RoomType entity)
        {
            return string.Join(_delimiter, entity.Id, entity.Name);
        }
    }
}
