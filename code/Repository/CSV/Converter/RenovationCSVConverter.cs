using Model.Director;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    public class RenovationCSVConverter : ICSVConverter<Renovation>
    {
        private readonly string _delimiter;

        public RenovationCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        //id, status, (beginDate, endDate), description, [3, 56, 54]
        public Renovation ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());

            return new Renovation(long.Parse(tokens[0]),
                (RenovationStatus) Enum.Parse(typeof(RenovationStatus),tokens[1]),
                StringToPeriod(tokens[2]),
                tokens[3],
                StringToList(tokens[4]
                ));
        }

        private Period StringToPeriod(string period)
        {
            period = period.Substring(1, period.Length-1);
            Period temp = new Period();

            string[] splits = period.Split(_delimiter.ToCharArray());

            temp.StartDate = DateTime.Parse(splits[0]);
            temp.EndDate = DateTime.Parse(splits[1]);

            return temp;
        }

        private List<Room> StringToList(string list)
        {
            list = list.Substring(1, list.Length - 1);

            List<Room> temp = new List<Room>();

            string[] splits = list.Split(_delimiter.ToCharArray());

            foreach (string RoomID in splits)
            {
                temp.Add(new Room(long.Parse(RoomID)));
            }

            return temp;
        }

        public string ConvertEntityToCSVFormat(Renovation entity)
        {
            StringBuilder sb = new StringBuilder();
            String formatted = String.Join(_delimiter, entity.GetId(), entity.Status);
            sb.Append(formatted);
            sb.Append(_delimiter);

            sb.Append("(");
            sb.Append(entity.Period.StartDate);
            sb.Append(_delimiter);
            sb.Append(entity.Period.EndDate);
            sb.Append(")");
            sb.Append(_delimiter);

            sb.Append(entity.Description);
            sb.Append(_delimiter);

            sb.Append("[");

            foreach (Room room in entity.Rooms)
            {
                sb.Append(room.GetId());
                sb.Append(_delimiter);
            }

            sb.Remove(sb.Length, 0);
            sb.Append("]");

            return sb.ToString();
        }
    }
}
