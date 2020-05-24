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
    class OperationCSVConverter : ICSVConverter<Operation>
    {
        private readonly string _delimiter;

        public OperationCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Operation ConvertCSVFormatToEntity(string entityCSVFormat)
        { 
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            Operation operation = new Operation(long.Parse(tokens[0]), new Doctor(long.Parse(tokens[1])), tokens[2],
                                    new Period(DateTime.Parse(tokens[3]), DateTime.Parse(tokens[4])), 
                                    new Room(long.Parse(tokens[5])), new PatientFile(long.Parse(tokens[6])));
            return operation;
        }

        //long id,Users.Doctor[] doctor, string description, Period period, Room room, PatientFile patientFile


        public string ConvertEntityToCSVFormat(Operation entity)
        {
            return string.Join(_delimiter, entity.Id, entity.doctor.GetId(), entity.Description, entity.period.StartDate, entity.period.EndDate,
                                  entity.room.GetId(), entity.patientFile.GetId());
        }
    }
}
