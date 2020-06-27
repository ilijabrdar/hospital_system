using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace bolnica.Repository.CSV.Converter
{
     public  class DiagnosisCSVConverter : ICSVConverter<Diagnosis>
    {
        private readonly String _delimiter;

        public DiagnosisCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Diagnosis ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            Diagnosis diagnosis = new Diagnosis(long.Parse(tokens[0]), tokens[1]);           

            return diagnosis;
        }

        public string ConvertEntityToCSVFormat(Diagnosis entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            String format = String.Join(_delimiter, entity.Id, entity.Name);
            stringBuilder.Append(format);
            stringBuilder.Append(_delimiter);
              
            return stringBuilder.ToString();
        }

    }
}
