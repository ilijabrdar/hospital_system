

using Model.Director;
using Model.PatientSecretary;
using System;
using Model.Users;


namespace Model.Dto
{
   public class ExaminationDTO
   {
      public Model.Users.Doctor Doctor { get; set; }
      public Model.Users.Patient Patient { get; set; }
      public Model.Director.Room Room { get; set; }
      public Model.PatientSecretary.Period Period { get; set; }

        public ExaminationDTO() { }
        public ExaminationDTO(Model.Users.Doctor doctor, Room room, Period period)
        {
            Doctor = doctor;
            Room = room;
            Period = period;
        }
   }
}