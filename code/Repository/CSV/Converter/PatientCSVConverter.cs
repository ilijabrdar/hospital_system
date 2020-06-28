using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace bolnica.Repository.CSV.Converter
{
   public class PatientCSVConverter : ICSVConverter<Patient>
    {
        private readonly string _delimiter;

        public PatientCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Patient ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            try
            {
                string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
                Patient patient = new Patient(long.Parse(tokens[0]), tokens[1], tokens[2], tokens[3], tokens[4], tokens[5], DateTime.Parse(tokens[6]), new Address(long.Parse(tokens[7]), long.Parse(tokens[8]), long.Parse(tokens[9])), tokens[10], tokens[11], new Uri(tokens[12]));
                patient.patientFile = new PatientFile(long.Parse(tokens[13]));
                patient.Guest = Boolean.Parse(tokens[14]);
                return patient;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
        public string ConvertEntityToCSVFormat(Patient entity)
        {
            return string.Join(_delimiter, entity.Id, entity.FirstName, entity.LastName, entity.Jmbg, entity.Email, entity.Phone, entity.DateOfBirth, entity.Address.GetId(), entity.Address.Town.GetId(), entity.Address.Town.State.GetId(), entity.Username, entity.Password, entity.Image.ToString(), entity.patientFile.GetId(), entity.Guest);
        }
    }
}
