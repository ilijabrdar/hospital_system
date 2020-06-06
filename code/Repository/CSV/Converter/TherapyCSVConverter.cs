using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    public class TherapyCSVConverter : ICSVConverter<Therapy>
    {
        private readonly String _delimiter = ",";

        public TherapyCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Therapy ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new Therapy(long.Parse(tokens[0]), DateTime.Parse(tokens[1]), DateTime.Parse(tokens[2]), int.Parse(tokens[3]), tokens[4]);

        }

        public string ConvertEntityToCSVFormat(Therapy entity)
        {
            return string.Join(_delimiter, entity.Id, entity.BeginDate, entity.EndDate, entity.DrugDosage, entity.Note);
        }
    }
}
