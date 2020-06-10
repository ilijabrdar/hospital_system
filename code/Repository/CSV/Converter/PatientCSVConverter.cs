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
                var formats = (from CultureInfo ct in CultureInfo.GetCultures(CultureTypes.AllCultures)
                               select ct.DateTimeFormat.GetAllDateTimePatterns()).SelectMany((x) => x).ToArray();
                string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
                /*  string[] period = tokens[6].Split(" ".ToCharArray());
                  string[] datum = period[0].Split(".".ToCharArray());
                  string[] time = period[1].Split(":".ToCharArray());*/
                // DateTime dateee = new DateTime(int.Parse(datum[2]), int.Parse(datum[0]), int.Parse(datum[1]), int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2]));
                Patient patient = new Patient(long.Parse(tokens[0]), tokens[1], tokens[2], tokens[3], tokens[4], tokens[5], DateTime.ParseExact(tokens[6], formats, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal), null, tokens[8], tokens[9], null);
                patient.patientFile = new PatientFile(long.Parse(tokens[11]));
                patient.Guest = Boolean.Parse(tokens[12]);
                return patient;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
        public string ConvertEntityToCSVFormat(Patient entity)
        {
            //  entity.Image.Save("../../Images/" + entity.Username + ".Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //String date = entity.DateOfBirth.ToString("MM.dd.yyyy HH:mm:ss");
            return string.Join(_delimiter, entity.Id, entity.FirstName, entity.LastName, entity.Jmbg, entity.Email, entity.Phone, entity.DateOfBirth, null, entity.Username, entity.Password, null,entity.patientFile.GetId(), entity.Guest);
        }
    }
}
