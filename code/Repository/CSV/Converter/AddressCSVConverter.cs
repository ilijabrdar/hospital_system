using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Users;

namespace bolnica.Repository.CSV.Converter
{
    public class AddressCSVConverter : ICSVConverter<Address>
    {
        private readonly string _delimiter;

        public AddressCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public Address ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new Address(tokens[0], int.Parse(tokens[1]), int.Parse(tokens[2]), new Town(long.Parse(tokens[3])));
        }

        public string ConvertEntityToCSVFormat(Address entity)
        {
            return string.Join(_delimiter, entity.Street, entity.Number, entity.ApartmentNumber, entity.GetTown().GetId());
        }
    }
}
