using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    public class DoctorGradeCSVConverter : ICSVConverter<DoctorGrade>
    {
        private readonly String _delimiter = ",";
        private readonly String _delimiterDictionary = ";";
        private readonly String _delimiterQuestionGrades = ":";

        public DoctorGradeCSVConverter(string delimiter, string delimiterDictionary, string delimiterQuestionGrades)
        {
            _delimiter = delimiter;
            _delimiterDictionary = delimiterDictionary;
            _delimiterQuestionGrades = delimiterQuestionGrades;
        }

        public DoctorGrade ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray()); 
            DoctorGrade doctorGrade = new DoctorGrade(long.Parse(tokens[0]), int.Parse(tokens[1]));

            string[] dictionaryPars = tokens[2].Split(_delimiterDictionary.ToCharArray()); 
            Dictionary<string, double> questionsGradesDictionary = new Dictionary<string, double>();

            string[] questionsGrades;

            for (int i = 0; i < dictionaryPars.Length; i++)
            {
                questionsGrades = dictionaryPars[i].Split(_delimiterQuestionGrades.ToCharArray());
                questionsGradesDictionary[questionsGrades[0]] = double.Parse(questionsGrades[1]);
            }

            doctorGrade.GradesForEachQuestions = questionsGradesDictionary;

            return doctorGrade;
        }

        public string ConvertEntityToCSVFormat(DoctorGrade entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            String format = String.Join(_delimiter, entity.Id, entity.NumberOfGrades);
            stringBuilder.Append(format);
            stringBuilder.Append(_delimiter);

            int numOfDelimiter = -1;
            foreach(KeyValuePair<String,double> map in entity.GradesForEachQuestions)
            {
                ++numOfDelimiter;
                stringBuilder.Append(map.Key);
                stringBuilder.Append(_delimiterQuestionGrades);
                stringBuilder.Append(map.Value);

                if(numOfDelimiter<entity.GradesForEachQuestions.Count-1)
                    stringBuilder.Append(_delimiterDictionary);

            }
            
            return stringBuilder.ToString();

        }
    }
}
