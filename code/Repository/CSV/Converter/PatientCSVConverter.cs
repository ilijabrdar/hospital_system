using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace bolnica.Repository.CSV.Converter
{
   public class PatientCSVConverter : ICSVConverter<Patient>
    {
        private readonly string _delimiter = ",";


        public Patient ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            try
            {
                string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
                string[] period = tokens[6].Split(" ".ToCharArray());
                string[] datum = period[0].Split(".".ToCharArray());
                string[] time = period[1].Split(":".ToCharArray());
                DateTime dateee = new DateTime(int.Parse(datum[2]), int.Parse(datum[0]), int.Parse(datum[1]),int.Parse(time[0]),int.Parse(time[1]), int.Parse(time[2]));
                Patient patient = new Patient(long.Parse(tokens[0]), tokens[1], tokens[2], tokens[3], tokens[4], tokens[5], dateee, tokens[7], tokens[8], tokens[9], null);
                patient.patientFile = new PatientFile(long.Parse(tokens[11]));
                return patient;
            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public string ConvertEntityToCSVFormat(Patient entity)
        {
            String date = entity.DateOfBirth.ToString("MM/dd/yyyy HH:mm:ss");
            return string.Join(_delimiter, entity.Id, entity.FirstName, entity.LastName, entity.Jmbg, entity.Email, entity.Phone, date, entity.address, entity.Username, entity.Password, entity.Image, entity.patientFile.GetId());
        }
    }
}
