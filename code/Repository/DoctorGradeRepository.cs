
using bolnica.Repository;
using Model.Doctor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository
{
   public class DoctorGradeRepository : CSVRepository<DoctorGrade,long> ,IDoctorGradeRepository
   {
        public DoctorGradeRepository(ICSVStream<DoctorGrade> stream, ISequencer<long> sequencer) : base(stream, sequencer)
        {

        }
    }
}