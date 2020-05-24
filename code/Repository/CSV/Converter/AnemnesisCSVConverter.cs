using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    public class AnemnesisCSVConverter : ICSVConverter<Anemnesis>
    {
        private readonly String _delimiter = ",";
        public Anemnesis ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            return new Anemnesis(entityCSVFormat);
        }
        //TODO resiti 
        public string ConvertEntityToCSVFormat(Anemnesis entity)
        {
            return entity.ToString();
        }
    }
}
