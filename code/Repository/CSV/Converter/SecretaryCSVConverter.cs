using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Model.Users;

namespace bolnica.Repository
{
    public class SecretaryCSVConverter : ICSVConverter<Secretary>
    {
        private readonly string _delimiter;
        
        public SecretaryCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Secretary ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new Secretary(long.Parse(tokens[0]), 
                tokens[1], tokens[2],  Image.FromFile(tokens[3]),
                tokens[4], tokens[5], tokens[6], tokens[7], tokens[8], DateTime.Parse(tokens[9]), new Address(long.Parse(tokens[8])));
        }

        public string ConvertEntityToCSVFormat(Secretary entity)
        {
            //TODO : ne mozemo da cuvamo sliku u CSV
            return String.Join(_delimiter, entity.GetId(), entity.Username, entity.Password, entity.Image, entity.FirstName, entity.Jmbg, entity.Email, entity.Phone, entity.DateOfBirth);
        }
    }
}
