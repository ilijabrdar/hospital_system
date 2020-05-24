using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    class ArticleCSVConverter : ICSVConverter<Article>
    {
        private readonly String _delimiter;
        public Article ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new Article(
                long.Parse(tokens[0]),
               (DateTime)DateTime.Parse(tokens[1]), tokens[2]);
            
        }

        public string ConvertEntityToCSVFormat(Article entity)
        {
            return string.Join(_delimiter, entity.Id, entity.DatePublished, entity.Topic);
        }
    }
}
