using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
   public class ArticleCSVConverter : ICSVConverter<Article>
   {
        private readonly String _delimiter;

        public ArticleCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Article ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            try
            {
                string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
                return new Article(
                    long.Parse(tokens[0]),
                   (DateTime)DateTime.Parse(tokens[1]), new Doctor(long.Parse(tokens[2])), tokens[3], tokens[4]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public string ConvertEntityToCSVFormat(Article entity)
        { 
            return string.Join(_delimiter, entity.Id, entity.DatePublished,entity.Doctor.GetId(), entity.Topic, entity.Text);
        }

    }
}
