using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace bolnica.Repository
{
    public class RoomCSVConverter : ICSVConverter<Room>
    {
        private readonly string _delimiter;

        public RoomCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public Room ConvertCSVFormatToEntity(string roomCSV)
        {
            string[] tokens = roomCSV.Split(_delimiter.ToCharArray());

            string dictionary = tokens[3];
            Dictionary<Equipment, int> helping = new Dictionary<Equipment, int>();

            dictionary = dictionary.Substring(1, dictionary.Length - 1);

            string[] pairs = dictionary.Split(_delimiter.ToCharArray());
            foreach (string pair in pairs)
            {
                string[] nums = pair.Split(":".ToCharArray());
                helping[new Equipment(long.Parse(nums[0]))] = int.Parse(nums[1]);
            }

            return new Room(
                long.Parse(tokens[0]),
                tokens[1],
                new RoomType(long.Parse(tokens[2])),
                helping,
                null);


        }

        public string ConvertEntityToCSVFormat(Room entity)
        {
            StringBuilder sb = new StringBuilder();
            String formatted = String.Join(_delimiter, entity.GetId(), entity.RoomCode, entity.RoomType.GetId());
            sb.Append(formatted);
            sb.Append(_delimiter);

            if (entity.Equipment_inventory.Count != 0)
            {
                sb.Append("{");  //dictionary delimiter

                foreach (KeyValuePair<Equipment, int> item in entity.Equipment_inventory)
                {
                    sb.Append(item.Key.GetId());
                    sb.Append(":");
                    sb.Append(item.Value);
                    sb.Append(_delimiter);
                }
                sb.Remove(sb.Length, 0);
                sb.Append("}");
            }

        //TODO: add list of renovations

            return sb.ToString();

            //return string.Join(_delimiter, entity.Id, entity.RoomCode);
        }
    }
}
