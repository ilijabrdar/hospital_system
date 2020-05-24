using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    class DrugCSVConverter : ICSVConverter<Drug>
    {
        private readonly string _delimiter;
        private readonly string _arraydelimiter;

        public DrugCSVConverter(string delimiter, string arraydel)
        {
            _delimiter = delimiter;
            _arraydelimiter = arraydel;
        }
        public Drug ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSVFormat(Drug entity)
        {
            throw new NotImplementedException();
        }
    }
}
