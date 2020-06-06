using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    class DiagnosisCSVConverter : ICSVConverter<Diagnosis>
    {
        private readonly String _delimiter = ",";
        private readonly string _symptomDelimiter;

        public DiagnosisCSVConverter(string delimiter, string symptomDelimiter)
        {
            _delimiter = delimiter;
            _symptomDelimiter = symptomDelimiter;
        }

        public Diagnosis ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            Diagnosis diagnosis = new Diagnosis(long.Parse(tokens[0]), tokens[1]);

            string[] Ids = tokens[2].Split(_symptomDelimiter.ToCharArray());
            List<Symptom> symptoms = new List<Symptom>();
            foreach(string id in Ids)
            {
                symptoms.Add(new Symptom(long.Parse(id)));
            }
            diagnosis.Symptom = symptoms;

            return diagnosis;


        }

        public string ConvertEntityToCSVFormat(Diagnosis entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            String format = String.Join(_delimiter, entity.Id, entity.Name);
            stringBuilder.Append(format);
            stringBuilder.Append(_delimiter);
            foreach(Symptom symptom in entity.Symptom)
            {
                stringBuilder.Append(symptom.GetId());
                stringBuilder.Append(_symptomDelimiter);
            }
            return stringBuilder.ToString();
        }
    }
}
