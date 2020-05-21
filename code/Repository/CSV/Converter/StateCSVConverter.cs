using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Users;

namespace bolnica.Repository
{
    public class StateCSVConverter : ICSVConverter<State>
    {
        private readonly string _delimiter;
        private readonly string _arrayDelimiter;
        
        public StateCSVConverter(string delimiter, string arrayDelimiter)
        {
            _delimiter = delimiter;
            _arrayDelimiter = arrayDelimiter;
        }

        public State ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            State state = new State(long.Parse(tokens[0]), tokens[1], tokens[2]);
            // TODO Dodati gradove u listu
            return state;
        }

        public string ConvertEntityToCSVFormat(State entity)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(entity.GetId());
            sb.Append(_delimiter);
            sb.Append(entity.Name);
            sb.Append(_delimiter);
            sb.Append(entity.Code);
            sb.Append(_delimiter);
            foreach(Town town in entity.GetTown())
            {
                sb.Append(town.GetId());
                sb.Append(_arrayDelimiter);
            }
            return sb.ToString();

        }
    }
}
