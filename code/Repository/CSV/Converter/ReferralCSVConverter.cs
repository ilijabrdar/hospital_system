using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    public class ReferralCSVConverter : ICSVConverter<Referral>
    {
        private readonly String _delimiter;

        public ReferralCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Referral ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new Referral(long.Parse(tokens[0]), new Period( DateTime.Parse(tokens[1]), DateTime.Parse(tokens[2])), new Doctor(long.Parse(tokens[3])));
        }

        public string ConvertEntityToCSVFormat(Referral entity)
        {
            return string.Join(_delimiter, entity.Id, entity.Period.StartDate, entity.Period.EndDate, entity.Doctor.GetId());
        }

    }
}
