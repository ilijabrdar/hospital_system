using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
   public class PatientCSVConverter : ICSVConverter<Patient>
    {
        private readonly string _delimiter = ",";


        public Patient ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            Patient patient = new Patient(long.Parse(tokens[0]), tokens[1], tokens[2], tokens[3], tokens[4], tokens[5], DateTime.Parse(tokens[6]), new Address(long.Parse(tokens[7])), tokens[8], tokens[9], (Bitmap)Bitmap.FromFile("../../Images"+tokens[8]+".Jpeg"));
            patient.patientFile = new PatientFile(long.Parse(tokens[10]));
            patient.Guest = Boolean.Parse(tokens[11]);
            return patient;
        }

        public string ConvertEntityToCSVFormat(Patient entity)
        {
            entity.Image.Save("../../Images/" + entity.Username + ".Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            return string.Join(_delimiter, entity.Id, entity.FirstName, entity.LastName, entity.Jmbg, entity.Email, entity.Phone, entity.DateOfBirth, entity.Address, entity.Username, entity.Password, entity.patientFile.GetId(), entity.Guest);
        }
    }
}
