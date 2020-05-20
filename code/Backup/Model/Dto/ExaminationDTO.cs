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
      private Model.Users.Doctor doctor;
      private Model.Users.Patient patient;
      private Model.Director.Room room;
      private Model.PatientSecretary.Period period;
   
   }
}