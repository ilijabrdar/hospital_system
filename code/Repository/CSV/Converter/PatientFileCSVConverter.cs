using Model.Doctor;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace bolnica.Repository.CSV.Converter
{
   public class PatientFileCSVConverter : ICSVConverter<PatientFile>
    {

        private readonly string _delimiter;
        private readonly string _arrayDelimiter;

        public PatientFileCSVConverter(string delimiter, string arrayDelimiter)
        {
            _delimiter = delimiter;
            _arrayDelimiter = arrayDelimiter;
        }

        public PatientFile ConvertCSVFormatToEntity(string entityCSVFormat)
        {
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());

            PatientFile patientFile = new PatientFile(long.Parse(tokens[0]));
            List<Allergy> allergyList = new List<Allergy>();
            if (!tokens[1].Equals("empty"))
            {
                String[] allergy = tokens[1].Split(_arrayDelimiter.ToCharArray());
                for(int i = 0; i < allergy.Length; i++)
                {
                    allergyList.Add(new Allergy(allergy[i]));
                }
            }
            patientFile.Allergy = allergyList;

            List<Hospitalization> hospitalizationList = new List<Hospitalization>();
            if (!tokens[2].Equals("empty"))
            {
                String[] hospitalization = tokens[2].Split(_arrayDelimiter.ToCharArray());
                for (int i = 0; i < hospitalization.Length; i++)
                {
                    hospitalizationList.Add(new Hospitalization(long.Parse(hospitalization[i])));
                }
            }
            patientFile.Hospitalization = hospitalizationList;

            List<Operation> operationList = new List<Operation>();
            if (!tokens[3].Equals("empty"))
            {
                String[] operation = tokens[3].Split(_arrayDelimiter.ToCharArray());
                for (int i = 0; i < operation.Length; i++)
                {
                    operationList.Add(new Operation(long.Parse(operation[i])));
                }
            }
            patientFile.Operation = operationList;

            List<Examination> examinationList = new List<Examination>();
            if (!tokens[4].Equals("empty"))
            {
                String[] examination = tokens[4].Split(_arrayDelimiter.ToCharArray());
                for (int i = 0; i < examination.Length; i++)
                {
                    examinationList.Add(new Examination(long.Parse(examination[i])));
                }
            }
            patientFile.Examination = examinationList;
            return patientFile;
        }

        public string ConvertEntityToCSVFormat(PatientFile entity)
        {
            StringBuilder sb = new StringBuilder();;
            sb.Append(entity.GetId());
            sb.Append(_delimiter);
            if(entity.Allergy == null)
            {
                sb.Append("empty");
            }else
            {
                foreach(Allergy allergy in entity.Allergy)
                {
                    sb.Append(allergy.Name);
                    sb.Append(_arrayDelimiter);
                }
                sb.Remove(sb.Length - 1, 1);
            }
            sb.Append(_delimiter);


            if(entity.Hospitalization == null)
            {
                sb.Append("empty");
            }else
            {
                foreach (Hospitalization hospitalization in entity.Hospitalization)
                {
                    sb.Append(hospitalization.GetId());
                    sb.Append(_arrayDelimiter);
                }
                sb.Remove(sb.Length - 1, 1);

            }
            sb.Append(_delimiter);


            if(entity.Operation == null)
            {
                sb.Append("empty");
            }else
            {
                foreach(Operation operation in entity.Operation)
                {
                    sb.Append(operation.GetId());
                    sb.Append(_arrayDelimiter);
                }
                sb.Remove(sb.Length - 1, 1);
            }
            sb.Append(_delimiter);


            if(entity.Examination == null)
            {
                sb.Append("empty");
            }else
            {
                foreach (Examination examination in entity.Examination)
                {
                    sb.Append(examination.GetId());
                    sb.Append(_arrayDelimiter);
                }
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }
    }
}
