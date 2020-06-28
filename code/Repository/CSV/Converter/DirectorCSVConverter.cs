﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Model.Users;

namespace bolnica.Repository.CSV.Converter
{
    public class DirectorCSVConverter : ICSVConverter<Director>
    {
        private readonly string _delimiter;

        public DirectorCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public Director ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new Director(long.Parse(tokens[0]),
                tokens[1], tokens[2], new Uri(tokens[3]),
                tokens[4], tokens[5], tokens[6], tokens[7], tokens[8], DateTime.Parse(tokens[9]), new Address(long.Parse(tokens[10]), long.Parse(tokens[11]), long.Parse(tokens[12])));
        }

        public string ConvertEntityToCSVFormat(Director entity)
        {
            return String.Join(_delimiter, entity.GetId(), 
                entity.Username, entity.Password, entity.Image.ToString(),
                entity.FirstName, entity.LastName, entity.Jmbg, entity.Email, entity.Phone, entity.DateOfBirth,
                entity.Address.GetId(), entity.Address.GetTown().GetId(), entity.Address.GetTown().GetState().GetId()
                );
        }
    }
}
