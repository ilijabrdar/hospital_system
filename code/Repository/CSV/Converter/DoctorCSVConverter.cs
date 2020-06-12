using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{

   public class DoctorCSVConverter : ICSVConverter<Doctor>

    {
        private readonly string _delimiter;

        public DoctorCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Doctor ConvertCSVFormatToEntity(string entityCSVFormat)
        {           // id, String name, String surname, String jmbg, String email, String phone, DateTime birth, String adress, town.Id, state.Id, String username, String password, Image img, Speciality spec
           string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());

            Doctor doct = new Doctor(long.Parse(tokens[0]), tokens[1], tokens[2], tokens[3], tokens[4], tokens[5], DateTime.Parse(tokens[6]), new Address(long.Parse(tokens[7]),long.Parse(tokens[8]),long.Parse(tokens[9])), tokens[10], tokens[11],null, new Speciality(long.Parse(tokens[12]))); //(Bitmap)Bitmap.FromFile("../../Images/"+tokens[8]+".Jpeg")
            doct.BusinessDay = new List<BusinessDay>();
            if (!tokens[13].Equals("empty"))
            {
                string[] articlesIds = tokens[12].Split("|".ToCharArray());
                for (int i = 0; i < articlesIds.Length; i++)
                    doct.Articles.Add(new Article(long.Parse(articlesIds[i])));
            }
            else
                doct.Articles = new List<Article>();
            if (!tokens[14].Equals("empty"))
            {
                string[] daysIds = tokens[14].Split("|".ToCharArray());
                for (int i = 0; i < daysIds.Length; i++)
                    doct.BusinessDay.Add(new BusinessDay(long.Parse(daysIds[i])));
            }
            else
                doct.BusinessDay = new List<BusinessDay>();
            if (!tokens[15].Equals("empty"))
            {
                doct.DoctorGrade = new DoctorGrade(long.Parse(tokens[14]));
            }
            //else doct.DoctorGrade = new DoctorGrade(1);
            
            return doct;
        }

        public string ConvertEntityToCSVFormat(Doctor entity)
        {
            StringBuilder sb = new StringBuilder();
           // entity.Image.Save("../../Images/" + entity.Username + "Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            string generalData = string.Join(_delimiter, entity.Id, entity.FirstName, entity.LastName, entity.Jmbg, entity.Email, 
                entity.Phone, entity.DateOfBirth, entity.Address.GetId(), entity.Address.Town.GetId(), entity.Address.Town.State.GetId(), entity.Username, entity.Password,  entity.Specialty.GetId());

            var article_count = entity.Articles == null ? 0 : entity.Articles.Count;

            sb.Append(generalData);
            sb.Append(_delimiter);
            if (article_count != 0)
            {
                foreach(Article article in entity.Articles)
                {
                    sb.Append(article.GetId());
                    sb.Append("|");
                }
                sb.Remove(sb.Length - 1, 1);
            }
            else
            {
                sb.Append("empty");
            }
           
            sb.Append(_delimiter);

            var businessDay_count = entity.BusinessDay == null ? 0 : entity.BusinessDay.Count;

            if (businessDay_count != 0)
            {
                foreach (BusinessDay day in entity.BusinessDay)
                {
                    sb.Append(day.GetId());
                    sb.Append("|");
                }
                sb.Remove(sb.Length - 1, 1);
            }
            else
            {
                sb.Append("empty");
            }
              sb.Append(_delimiter);

            if (entity.DoctorGrade != null)
                sb.Append(entity.DoctorGrade.GetId());
            else
                sb.Append("empty");
            return sb.ToString();
        }
    }
}
