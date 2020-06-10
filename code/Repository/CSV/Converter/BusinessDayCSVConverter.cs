using Model.Director;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bolnica.Repository.CSV.Converter
{
   public class BusinessDayCSVConverter : ICSVConverter<BusinessDay>
    {
        private readonly String _delimiter = ",";

        public BusinessDayCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public BusinessDay ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            if (tokens[5].Equals("empty"))
                return new BusinessDay(long.Parse(tokens[0]), new Period(DateTime.Parse(tokens[1]), DateTime.Parse(tokens[2])), new Doctor(long.Parse(tokens[3])), new Room(long.Parse(tokens[4])), new List<Period>());
            else
            {
                List<Period> scheduledPeriods = new List<Period>();
                string[] periods = tokens[5].Split("|".ToCharArray());
                for(int i = 0; i < periods.Length; i++)
                {
                    string[] times = periods[i].Split("*".ToCharArray());
                    scheduledPeriods.Add(new Period(DateTime.Parse(times[0]), DateTime.Parse(times[1])));
                }
                return new BusinessDay(long.Parse(tokens[0]), new Period(DateTime.Parse(tokens[1]), DateTime.Parse(tokens[2])), new Doctor(long.Parse(tokens[3])), new Room(long.Parse(tokens[4])), scheduledPeriods);

            }
        }

        public string ConvertEntityToCSVFormat(BusinessDay entity)
        {
            StringBuilder sb = new StringBuilder();
            String basicData = String.Join(_delimiter, entity.Id, entity.Shift.StartDate, entity.Shift.StartDate, entity.doctor.GetId(), entity.room.GetId());
            sb.Append(basicData);
            sb.Append(_delimiter);
            if (entity.ScheduledPeriods.Count == 0)
                sb.Append("empty");
            else
            {
                foreach(Period period in entity.ScheduledPeriods)
                {
                    sb.Append(period.StartDate);
                    sb.Append("*");
                    sb.Append(period.EndDate);
                    sb.Append("|");
                }
                sb.Remove(sb.Length - 1, 1);
            }
          
            return sb.ToString();
        }
    }
}
