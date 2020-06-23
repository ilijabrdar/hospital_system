using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
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
            Hospitalization hospitalization = new Hospitalization(long.Parse(tokens[0]), new Period(DateTime.Parse(tokens[1]), DateTime.Parse(tokens[2])), new Room(long.Parse(tokens[3])));
            return hospitalization;
        }

        public string ConvertEntityToCSVFormat(Hospitalization entity)
        {
            return string.Join(_delimiter, entity.Id, entity.Period.StartDate, entity.Period.EndDate, entity.Room.GetId());
        }

    }
}
