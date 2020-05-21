using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
    public class IngredientsCSVConverter : ICSVConverter<Ingredient>
    {
        private readonly string _delimiter;

        public IngredientsCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }
        public Ingredient ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new Ingredient(
                long.Parse(tokens[0]),
                tokens[1],
                int.Parse(tokens[2]));
        }

        public string ConvertEntityToCSVFormat(Ingredient entity)
        {
            return string.Join(_delimiter, entity.Id, entity.Name, entity.Quantity);
        }
    }
}
