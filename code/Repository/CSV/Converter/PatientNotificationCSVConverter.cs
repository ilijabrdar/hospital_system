using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bolnica.Model.Dto;
using Model.Users;

namespace bolnica.Repository.CSV.Converter
{
    public class PatientNotificationCSVConverter : ICSVConverter<PatientNotification>
    {
        private readonly String _delimiter;

        public PatientNotificationCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public PatientNotification ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new PatientNotification(long.Parse(tokens[0]), new Patient(long.Parse(tokens[1])), Boolean.Parse(tokens[2]), tokens[3]);
        }

        public string ConvertEntityToCSVFormat(PatientNotification entity)
        {
            return string.Join(_delimiter, entity.Id, entity.Patient.Id, entity.Read, entity.Message);
        }
    }
}
