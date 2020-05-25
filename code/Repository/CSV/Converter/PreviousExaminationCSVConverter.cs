using bolnica.Service;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    class PreviousExaminationCSVConverter : ICSVConverter<Examination>
    {
        private readonly string _delimiter;

        public PreviousExaminationCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Examination ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            Examination examination = new Examination(long.Parse(tokens[0]),
                                                        new Doctor(long.Parse(tokens[2])), new Period(DateTime.Parse(tokens[3])),
                                                        new Diagnosis(long.Parse(tokens[4])), new Prescription(long.Parse(tokens[5])),
                                                        new Anemnesis(tokens[6]), new Therapy(long.Parse(tokens[7])), new Refferal(long.Parse(tokens[8])));

            examination.User = new Patient(long.Parse(tokens[1]));
            return examination;
        }

        public string ConvertEntityToCSVFormat(Examination entity)
        {
            return string.Join(_delimiter, entity.Id, entity.User.GetId(), entity.Doctor.GetId(), entity.Period.StartDate,
                                entity.Diagnosis.GetId(), entity.Prescription.GetId(),entity.Anemnesis,entity.Therapy.GetId(), entity.Refferal.GetId());
        }
    }
}
