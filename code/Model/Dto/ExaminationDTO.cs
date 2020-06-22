

using Model.Director;
using Model.PatientSecretary;
using System;
using Model.Users;


namespace Model.Dto
{
    public class ExaminationDTO
    {
        public long Id { get; set; }
        public Model.Users.Doctor Doctor { get; set; }
        public Model.Users.Patient Patient { get; set; }
        public Model.Director.Room Room { get; set; }
        public Model.PatientSecretary.Period Period { get; set; }

        public ExaminationDTO() { }

        public ExaminationDTO(long id, Model.Users.Doctor doctor, Room room, Period period, Patient patient)
        {
            Id = id;
            Doctor = doctor;
            Room = room;
            Period = period;
            Patient = patient;
        }

        public ExaminationDTO(Model.Users.Doctor doctor, Room room, Period period, Patient patient)
        {
            Doctor = doctor;
            Room = room;
            Period = period;
            Patient = patient;
        }


        public ExaminationDTO(Model.Users.Doctor doctor, Room room, Period period)
        {
            Doctor = doctor;
            Room = room;
            Period = period;
        }

        public ExaminationDTO( Patient patient, Period period)
        {
            Patient = patient;
            Period = period;
        }

        public ExaminationDTO(Room room, Period period)
        {
            Room = room;
            Period = period;
        }
    }
}
