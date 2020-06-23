using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    public class PrescriptionCSVConverter : ICSVConverter<Prescription>
    {
        private readonly String _delimiter = ",";
        private readonly String _drugDelimiter = ";";

        public PrescriptionCSVConverter(string delimiter, string drugDelimiter)
        {
            _delimiter = delimiter;
            _drugDelimiter = drugDelimiter;
        }

        public Prescription ConvertCSVFormatToEntity(string entityCSVFormat)
        {  
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            Prescription prescription = new Prescription(long.Parse(tokens[0]), new Period(DateTime.Parse(tokens[1]), DateTime.Parse(tokens[2])));

            string[] drugIds = tokens[3].Split(_drugDelimiter.ToCharArray());
            List<Drug> Drugs = new List<Drug>();

            foreach(string id in drugIds)
            {
                Drugs.Add(new Drug(long.Parse(id)));

            }

            prescription.Drug = Drugs;

            return prescription;

        }

        public string ConvertEntityToCSVFormat(Prescription entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            String format = String.Join(_delimiter, entity.Id, entity.Period.StartDate, entity.Period.EndDate);
            stringBuilder.Append(format);
            stringBuilder.Append(_delimiter);


            foreach (Drug drug in entity.Drug)
            {  
                stringBuilder.Append(drug.GetId());
                stringBuilder.Append(_drugDelimiter);
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            return stringBuilder.ToString();
        }
    }
}
