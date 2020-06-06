/***********************************************************************
 * Module:  ExaminationDTO.cs
 * Author:  Asus
 * Purpose: Definition of the Class Model.Dto.ExaminationDTO
 ***********************************************************************/

using System;

namespace Model.Dto
{
   public class ExaminationDTO
   {
      public Model.Users.Doctor doctor { get; set; }
      public Model.Users.Patient patient { get; set; }
      public Model.Director.Room room { get; set; }
      public Model.PatientSecretary.Period period { get; set; }
     
        public ExaminationDTO()
        {

        }

    }
}