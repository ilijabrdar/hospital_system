using bolnica.Service;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;

namespace bolnica.Repository.CSV.Converter
{
   public class PreviousExaminationCSVConverter : ICSVConverter<Examination>
    {
        private readonly string _delimiter;

        public PreviousExaminationCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Examination ConvertCSVFormatToEntity(string entityCSVFormat)
        {

            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            Examination examination = new Examination(long.Parse(tokens[0]), (User)new Patient(long.Parse(tokens[1])),
                                                        new Doctor(long.Parse(tokens[2])), new Period(DateTime.Parse(tokens[3])),
                                                        new Diagnosis(long.Parse(tokens[4])),
                                                        new Anemnesis(tokens[5]), new Therapy(long.Parse(tokens[6])), new Referral(long.Parse(tokens[7])),
                                                        new Prescription(long.Parse(tokens[8])));
                
                return examination;
        }

        public string ConvertEntityToCSVFormat(Examination entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            String format = String.Join(_delimiter, entity.Id, entity.User.GetId(), entity.Doctor.GetId(), entity.Period.StartDate,
                                entity.Diagnosis.GetId(), entity.Anemnesis.Text , entity.Therapy.GetId(), entity.Refferal.GetId(), entity.Prescription.GetId());

            stringBuilder.Append(format);

            return stringBuilder.ToString();
                
           
        }
    }
}
