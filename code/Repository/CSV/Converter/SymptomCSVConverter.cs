using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    public class SymptomCSVConverter : ICSVConverter<Symptom>
    {

        private readonly String _delimiter = ",";

        public SymptomCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Symptom ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new Symptom(long.Parse(tokens[0]), tokens[1]);
           
        }

        public string ConvertEntityToCSVFormat(Symptom entity)
        {
            return string.Join(_delimiter, entity.Id, entity.Name);

        }
    }
}
