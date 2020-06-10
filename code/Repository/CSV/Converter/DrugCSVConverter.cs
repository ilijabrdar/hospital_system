using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
   public class DrugCSVConverter : ICSVConverter<Drug>
    {
        private readonly string _delimiter;
        //private readonly string _arraydelimiter;

        public DrugCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
            //_arraydelimiter = arraydel;
        }
        public Drug ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());

            string ingredients_token = tokens[4];
            string alternative_drugs_token = tokens[5];
            List<Ingredient> ingredients_temp = new List<Ingredient>();
            List<Drug> alternatives_temp = new List<Drug>();

            if (!ingredients_token.Contains("empty"))
            {
                ingredients_token = ingredients_token.Substring(1, ingredients_token.Length - 2);
                string[] ids = ingredients_token.Split("!".ToCharArray());
                foreach (String id in ids)
                {
                    ingredients_temp.Add(new Ingredient(long.Parse(id)));
                }
            }
            if (!alternative_drugs_token.Contains("empty"))
            {
                alternative_drugs_token = alternative_drugs_token.Substring(1, alternative_drugs_token.Length - 2);
                string[] ids = alternative_drugs_token.Split("!".ToCharArray());
                foreach(String id in ids)
                {
                    alternatives_temp.Add(new Drug(long.Parse(id)));
                }
            }

            return new Drug(
                long.Parse(tokens[0]),
                tokens[1],
                int.Parse(tokens[2]),
                bool.Parse(tokens[3]),
                ingredients_temp,
                alternatives_temp);
        }


        //id,name,amount,false,[2,4,3,5,1],[5,4,10,44]
        public string ConvertEntityToCSVFormat(Drug entity)
        {
            StringBuilder sb = new StringBuilder();
            String formatted = String.Join(_delimiter, entity.GetId(), entity.Name, entity.Amount, entity.Approved);
            sb.Append(formatted);
            sb.Append(_delimiter);

            var ingredients_count = entity.Ingredients == null ? 0 : entity.Ingredients.Count();

            if (ingredients_count!=0)
            {
                sb.Append("[");
                foreach (Ingredient ingredient in entity.Ingredients)
                {
                    sb.Append(ingredient.Id);
                    sb.Append("!");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("],");
            }
            else
                sb.Append("empty,");
            

            var alternative_count = entity.Alternative == null ? 0 : entity.Alternative.Count();

            if (alternative_count != 0)
            {
                sb.Append("[");
                foreach (Drug alternativeDrug in entity.Alternative)
                {
                    sb.Append(alternativeDrug.Id);
                    sb.Append("!");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("]");
            }
            else
                sb.Append("empty");

            return sb.ToString();
        }
    }
}
