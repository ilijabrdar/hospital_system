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
                                                        new Diagnosis(long.Parse(tokens[4])));
            if (!tokens[5].Equals("empty"))
            {
                examination.Anemnesis = new Anemnesis(tokens[5]);
            }
            if (!tokens[6].Equals("empty"))
            {
                examination.Therapy = new Therapy(long.Parse(tokens[6]));
            }
            if (!tokens[7].Equals("empty"))
            { 
                examination.Refferal = new Referral(long.Parse(tokens[7]));
            }
            if (!tokens[8].Equals("empty"))
            {
                examination.Prescription = new Prescription(long.Parse(tokens[8]));
            }

                return examination;
        }

        public string ConvertEntityToCSVFormat(Examination entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            String format = String.Join(_delimiter, entity.Id, entity.User.GetId(), entity.Doctor.GetId(), entity.Period.StartDate,
                                entity.Diagnosis.GetId()); 
            stringBuilder.Append(format);
            stringBuilder.Append(_delimiter);

            if (entity.Anemnesis == null)
                stringBuilder.Append("empty");
            else
                stringBuilder.Append(entity.Anemnesis.Text);

            stringBuilder.Append(_delimiter);

            if (entity.Therapy == null)
                stringBuilder.Append("empty");
            else
                stringBuilder.Append(entity.Therapy.GetId());
            stringBuilder.Append(_delimiter);

            if (entity.Refferal == null)
                stringBuilder.Append("empty");
            else
                stringBuilder.Append(entity.Refferal.GetId());
            stringBuilder.Append(_delimiter);

            if (entity.Prescription == null)
                stringBuilder.Append("empty");
            else
                stringBuilder.Append(entity.Prescription.GetId());


            return stringBuilder.ToString();
                
           
        }
    }
}
