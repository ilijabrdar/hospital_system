using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    public class HospitalizationCSVConverter : ICSVConverter<Hospitalization>
    {
        private readonly string _delimiter;

        public HospitalizationCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public Hospitalization ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            Hospitalization hospitalization = new Hospitalization(long.Parse(tokens[0]), (User) new Patient(long.Parse(tokens[1])), new Doctor(long.Parse(tokens[2])), new Period(DateTime.Parse(tokens[3]), DateTime.Parse(tokens[4])), new Room(long.Parse(tokens[5])));
            return hospitalization;
        }

        public string ConvertEntityToCSVFormat(Hospitalization entity)
        {
            return string.Join(_delimiter, entity.Id, entity.Patient.GetId(), entity.Doctor.GetId(), entity.Period.StartDate, entity.Period.EndDate, entity.Room.GetId());
        }

    }
}
