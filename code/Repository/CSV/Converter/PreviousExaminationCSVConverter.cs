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
        private readonly string _prescriptonDelimiter;

        public PreviousExaminationCSVConverter(string delimiter, string prescriptonDelimiter)
        {
            _delimiter = delimiter;
            _prescriptonDelimiter = prescriptonDelimiter;
        }

        public Examination ConvertCSVFormatToEntity(string entityCSVFormat)
        {//(long id, User user, Users.Doctor doctor, Period period, Diagnosis diagnosis, Anemnesis anemnesis, Therapy therapy, Referral refferal)

            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            Examination examination = new Examination(long.Parse(tokens[0]), (User)new Patient(long.Parse(tokens[1])),
                                                        new Doctor(long.Parse(tokens[2])), new Period(DateTime.Parse(tokens[3])),
                                                        new Diagnosis(long.Parse(tokens[4])),
                                                        new Anemnesis(tokens[5]), new Therapy(long.Parse(tokens[6])), new Referral(long.Parse(tokens[7])));

            examination.User = new Patient(long.Parse(tokens[1]));

            string[] Ids = (tokens[8]).Split(_prescriptonDelimiter.ToCharArray());
            List < Prescription > prescriptions= new List<Prescription>();
            foreach(string id in Ids)
            {
                prescriptions.Add(new Prescription(long.Parse(id)));
            }
            examination.Prescription=prescriptions;
                
                return examination;
        }

        public string ConvertEntityToCSVFormat(Examination entity)
        {
            StringBuilder stringBuilder = new StringBuilder();
            String format = String.Join(_delimiter, entity.Id, entity.User.GetId(), entity.Doctor.GetId(), entity.Period.StartDate,
                                entity.Diagnosis.GetId(), entity.Anemnesis.Text , entity.Therapy.GetId(), entity.Refferal.GetId());

            stringBuilder.Append(format);
            stringBuilder.Append(_delimiter);
            foreach(Prescription prescription in entity.Prescription)
            {
                stringBuilder.Append(prescription.GetId());
                stringBuilder.Append(_prescriptonDelimiter);
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);

            return stringBuilder.ToString();
                
           
        }
    }
}
