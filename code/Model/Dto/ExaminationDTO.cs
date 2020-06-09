

using System;


namespace Model.Dto
{
   public class ExaminationDTO
   {
      public Model.Users.Doctor Doctor { get; set; }
      public Model.Users.Patient Patient { get; set; }
      public Model.Director.Room Room { get; set; }
      public Model.PatientSecretary.Period Period { get; set; }

        public ExaminationDTO() { }
   
   }
}