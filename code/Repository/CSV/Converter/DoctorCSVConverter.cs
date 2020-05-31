﻿using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace bolnica.Repository.CSV.Converter
{
    class DoctorCSVConverter : ICSVConverter<Doctor>
    {
        private readonly string _delimiter;

        public DoctorCSVConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Doctor ConvertCSVFormatToEntity(string entityCSVFormat)
        {
           string[] tokens = entityCSVFormat.Split(_delimiter.ToCharArray());
            Doctor doct = new Doctor(long.Parse(tokens[0]), tokens[1], tokens[2], tokens[3], tokens[4], tokens[5], DateTime.Parse(tokens[6]), tokens[7], tokens[8], tokens[9],Image.FromFile(tokens[10]), new Specialty(long.Parse(tokens[11])));
            if (!tokens[12].Equals("empty"))
            {
                string[] articlesIds = tokens[12].Split("|".ToCharArray());
                for (int i = 0; i < articlesIds.Length; i++)
                    doct.articles.Add(new Article(long.Parse(articlesIds[i])));
            }
            if (!tokens[13].Equals("empty"))
            {
                string[] daysIds = tokens[13].Split("|".ToCharArray());
                for (int i = 0; i < daysIds.Length; i++)
                    doct.businessDay.Add(new BusinessDay(long.Parse(daysIds[i])));
            }
            if (!tokens[14].Equals("empty"))
            {
                doct.doctorGrade = new DoctorGrade(long.Parse(tokens[14]));
            }
            return doct;
        }

        public string ConvertEntityToCSVFormat(Doctor entity)
        {
            StringBuilder sb = new StringBuilder();
            string generalData = string.Join(_delimiter, entity.Id, entity.FirstName, entity.LastName, entity.Jmbg, entity.Email, entity.Phone, entity.DateOfBirth, entity.address, entity.Username, entity.Password, entity.Image, entity.specialty);
            sb.Append(generalData);
            sb.Append(_delimiter);
            if(entity.articles.Count != 0)
            {
                foreach(Article article in entity.articles)
                {
                    sb.Append(article.GetId());
                    sb.Append("|");
                }
                sb.Remove(sb.Length - 1, 1);
            }
            else
            {
                sb.Append("empty");
            }
           
            sb.Append(_delimiter);
            if (entity.businessDay.Count != 0)
            {
                foreach (BusinessDay day in entity.businessDay)
                {
                    sb.Append(day.GetId());
                    sb.Append("|");
                }
                sb.Remove(sb.Length - 1, 1);
            }
            else
            {
                sb.Append("empty");
            }
              sb.Append(_delimiter);

            if (entity.doctorGrade != null)
                sb.Append(entity.doctorGrade.GetId());
            else
                sb.Append("empty");
            return sb.ToString();
        }
    }
}