using Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
    public class SpecialityCSVConverter : ICSVConverter<Speciality>
    {
        private readonly String _delimiter;

        public SpecialityCSVConverter (String delimiter)
        {
            this._delimiter = delimiter;
        }

        public Speciality ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            return new Speciality( long.Parse(tokens[0]), tokens[1]);
        }

        public string ConvertEntityToCSVFormat(Speciality entity)
        {
            return string.Join(_delimiter, entity.Id, entity.Name);
        }

    }
}
