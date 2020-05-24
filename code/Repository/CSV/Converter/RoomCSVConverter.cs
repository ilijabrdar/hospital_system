using Model.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace bolnica.Repository
{
    public class RoomCSVConverter : ICSVConverter<Room>  //TODO: fix for cases where there is not dictionary
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

            if (dictionary.Contains("{"))  // if there's no dictionary it crashes
            {
                dictionary = dictionary.Substring(1, dictionary.Length - 2);

                string[] pairs = dictionary.Split("!".ToCharArray());
                foreach (string pair in pairs)
                {
                    string[] nums = pair.Split(":".ToCharArray());
                    helping[new Equipment(long.Parse(nums[0]))] = int.Parse(nums[1]);
                }
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

            if (entity.Equipment_inventory != null)
            {
                sb.Append("{");  //dictionary delimiter

                foreach (KeyValuePair<Equipment, int> item in entity.Equipment_inventory)
                {
                    sb.Append(item.Key.GetId());
                    sb.Append(":");
                    sb.Append(item.Value);
                    sb.Append("!");
                }
                sb.Remove(sb.Length-1, 1);
                sb.Append("}");
            }
            else
            {
                sb.Append("empty");
            }

        //TODO: add list of renovations

            return sb.ToString();

            //return string.Join(_delimiter, entity.Id, entity.RoomCode);
        }
    }
}
