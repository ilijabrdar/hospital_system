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
        private readonly String _drugDelimiter = ";";

        public TherapyCSVConverter(string delimiter, string drugDelimiter)
        {
            _delimiter = delimiter;
            _drugDelimiter = drugDelimiter;
        }

        public Therapy ConvertCSVFormatToEntity(string entityCSVFormat)
        {//    public Therapy(long id, Period period, int drugDosage, string note, List<Drug> drug) 
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            Therapy therapy = new Therapy(long.Parse(tokens[0]), new Period(DateTime.Parse(tokens[1]), DateTime.Parse(tokens[2])), tokens[3]);
            string[] drugIds = tokens[4].Split(_drugDelimiter.ToCharArray());
            List<Drug> Drugs = new List<Drug>();

            foreach (string id in drugIds)
            {
                Drugs.Add(new Drug(long.Parse(id)));

            }

            therapy.Drug = Drugs;

            return therapy;

        }

        public string ConvertEntityToCSVFormat(Therapy entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            String format = String.Join(_delimiter, entity.Id, entity.Period.StartDate, entity.Period.EndDate,entity.Note);
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
