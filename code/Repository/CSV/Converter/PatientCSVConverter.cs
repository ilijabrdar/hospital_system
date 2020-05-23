using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    class PatientCSVConverter : ICSVConverter<Patient>
    {
        private readonly string _delimiter;

        public PatientCSVConverter(string delimiter, string arrayDelimiter)
        {
            _delimiter = delimiter;
        }
        public Patient ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new Patient(long.Parse(tokens[0]), tokens[1], tokens[2], tokens[3], tokens[4], tokens[5], DateTime.Parse(tokens[6]), tokens[7], tokens[8], tokens[9], Image.FromFile(tokens[10]),new PatientFile(long.Parse(tokens[11])));
            
        }

        public string ConvertEntityToCSVFormat(Patient entity)
        {
            return string.Join(_delimiter, entity.Id, entity.FirstName, entity.LastName, entity.Jmbg, entity.Email, entity.Phone, entity.DateOfBirth, entity.address, entity.Username, entity.Password, entity.Image, entity.patientFile.GetId());
        }
    }
}
