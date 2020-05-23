using Model.Doctor;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    class PatientFileCSVConverter : ICSVConverter<PatientFile>
    {
        //TODO : potrebno je ubaciti sve liste u ovu klasu i person, ali radio sam registraciju pa mi to tad nije bilo hitno
        private readonly string _delimiter;
        private readonly string _arrayDelimiter;

        public PatientFileCSVConverter(string delimiter, string arrayDelimiter)
        {
            _delimiter = delimiter;
            _arrayDelimiter = arrayDelimiter;
        }
        public PatientFile ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSVFormat(PatientFile entity)
        {
            return String.Join(_delimiter, entity.Id);
        }
    }
}
