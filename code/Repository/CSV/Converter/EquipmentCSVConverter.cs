using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
    public class EquipmentCSVConverter : ICSVConverter<Equipment>
    {
        private readonly string _delimiter;

        public EquipmentCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public Equipment ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            var temp = new Equipment(
                long.Parse(tokens[0]),
                (EquipmentType)Enum.Parse(typeof(EquipmentType), tokens[1]), tokens[2], int.Parse(tokens[3])
                );
            return temp;
        }

        public string ConvertEntityToCSVFormat(Equipment entity)
        {
            return string.Join(_delimiter, entity.id,entity.Type, entity.Name, entity.Amount);
        }
    }
}
