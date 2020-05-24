using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    class UpcomingExaminationCSVConverter : ICSVConverter<Examination>
    {
        private readonly string _delimiter;

        public UpcomingExaminationCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Examination ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            //long id, Patient patient, Users.Doctor doctor, Period period
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            Examination examination = new Examination(long.Parse(tokens[0]), new Patient(long.Parse(tokens[1])),
                                                        new Doctor(long.Parse(tokens[2])), new Period(DateTime.Parse(tokens[3])));
            return examination;
        }

        public string ConvertEntityToCSVFormat(Examination entity)
        {
            return string.Join(_delimiter, entity.Id, entity.Patient.GetId(), entity.Doctor.GetId(), entity.Period.StartDate);
        }
    }
}
