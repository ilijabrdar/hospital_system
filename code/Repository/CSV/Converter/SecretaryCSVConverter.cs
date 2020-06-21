using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using Model.Users;

namespace bolnica.Repository
{
    public class SecretaryCSVConverter : ICSVConverter<Secretary>
    {
        private readonly string _delimiter;
        
        public SecretaryCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Secretary ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new Secretary(long.Parse(tokens[0]), 
                tokens[1], tokens[2], /*(Bitmap) Bitmap.FromFile("../../../../UserInterface/UserInterface/Resources/Images/" + tokens[1] + ".Jpeg")*/null/* (Bitmap)Bitmap.FromFile("C:/Users/Asus/Desktop/SIMS/hospital_system/UserInterface/UserInterface/Resources/Images/Pera.Jpeg")*/,
                tokens[4], tokens[5], tokens[6], tokens[7], tokens[8], DateTime.ParseExact(tokens[9], "dd.MM.yyyy", CultureInfo.InvariantCulture), new Address(long.Parse(tokens[10]), long.Parse(tokens[11]), long.Parse(tokens[12])));;
        }

        public string ConvertEntityToCSVFormat(Secretary entity)
        {
            //entity.Image.Save("../../Images/"+entity.Username+".Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
<<<<<<< HEAD
            return String.Join(_delimiter, entity.GetId(), entity.Username, entity.Password, "...", entity.FirstName, entity.LastName, entity.Jmbg, entity.Email, entity.Phone, entity.DateOfBirth.ToString("dd.MM.yyyy"), entity.Address.GetId(), entity.Address.Town.GetId(), entity.Address.Town.State.GetId(), entity.Loged) ;
=======
            return String.Join(_delimiter, entity.GetId(), entity.Username, entity.Password, "...", entity.FirstName, entity.LastName, entity.Jmbg, entity.Email, entity.Phone, entity.DateOfBirth.ToString("dd.MM.yyyy"), entity.Address.GetId(), entity.Address.Town.GetId(), entity.Address.Town.State.GetId());
>>>>>>> master
        }
    }
}
