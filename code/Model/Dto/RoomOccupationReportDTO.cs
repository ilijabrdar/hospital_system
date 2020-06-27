using Model.Director;
using Model.Doctor;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Model.Dto
{
    public class RoomOccupationReportDTO
    {
        public Room room { get; set; }

        public List<Renovation> renovations { get; set; }

        public List<Operation> operations { get; set; }

        public List<Examination> examinations { get; set; }

        public List<Examination> previousExaminations { get; set; }

        public List<Hospitalization> hospitalizations { get; set; }

        public Period period { get; set; }

        public RoomOccupationReportDTO()
        {

        }

        public RoomOccupationReportDTO(Room room, List<Renovation> renovations, List<Operation> operations, List<Examination> examinations, List<Hospitalization> hospitalizations, Period period, List<Examination> previousExam)
        {
            this.room = room;
            this.renovations = renovations;
            this.operations = operations;
            this.examinations = examinations;
            this.hospitalizations = hospitalizations;
            this.period = period;
            this.previousExaminations = previousExam;
        }
    }
}
