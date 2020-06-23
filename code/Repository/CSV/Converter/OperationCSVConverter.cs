using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace bolnica.Repository
{
    public class OperationCSVConverter : ICSVConverter<Operation>
    {
        private readonly string _delimiter;

        public OperationCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Operation ConvertCSVFormatToEntity(string entityCSVFormat)
        { 
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            Operation operation = new Operation(long.Parse(tokens[0]), (User)new Patient(long.Parse(tokens[1])), new Doctor(long.Parse(tokens[2])), tokens[3], new Period(DateTime.Parse(tokens[4]), DateTime.Parse(tokens[5])), new Room(long.Parse(tokens[6])));
            return operation;
        }

        public string ConvertEntityToCSVFormat(Operation entity)
        {
            return string.Join(_delimiter, entity.Id, entity.Patient.GetId(), entity.Doctor.GetId(), entity.Description, entity.Period.StartDate, entity.Period.EndDate, entity.Room.GetId());
        }

    }
}
