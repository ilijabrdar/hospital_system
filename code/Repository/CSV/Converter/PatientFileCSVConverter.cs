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

        private readonly string _delimiter = ",";
        private readonly string _arrayDelimiter = "|";


        public PatientFile ConvertCSVFormatToEntity(string entityCSVFormat)
        { 
            string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());

            PatientFile patientFile = new PatientFile(long.Parse(tokens[0]));
            if (!tokens[1].Equals("empty"))
            {
                String[] allergy = tokens[1].Split(_arrayDelimiter.ToCharArray());
                for(int i = 0; i < allergy.Length; i++)
                {
                    patientFile.Allergy.Add(new Allergy(allergy[i]));
                }
            }
            if (!tokens[2].Equals("empty"))
            {
                String[] hospitalization = tokens[2].Split(_arrayDelimiter.ToCharArray());
                for (int i = 0; i < hospitalization.Length; i++)
                {
                    patientFile.Hospitalization.Add(new Hospitalization(long.Parse(hospitalization[i])));
                }
            }
            if (!tokens[3].Equals("empty"))
            {
                String[] operation = tokens[3].Split(_arrayDelimiter.ToCharArray());
                for (int i = 0; i < operation.Length; i++)
                {
                    patientFile.Operation.Add(new Operation(long.Parse(operation[i])));
                }
            }
            if (!tokens[4].Equals("empty"))
            {
                String[] examination = tokens[4].Split(_arrayDelimiter.ToCharArray());
                for (int i = 0; i < examination.Length; i++)
                {
                    patientFile.Examination.Add(new Examination(long.Parse(examination[i])));
                }
            }
            return patientFile;
        }

        public string ConvertEntityToCSVFormat(PatientFile entity)
        {
            StringBuilder sb = new StringBuilder();;
            sb.Append(entity.GetId());
            sb.Append(_delimiter);
            if(entity.Allergy.Count == 0)
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
            if(entity.Hospitalization.Count == 0)
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
            if(entity.Operation.Count == 0)
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
            if(entity.Examination.Count == 0)
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
