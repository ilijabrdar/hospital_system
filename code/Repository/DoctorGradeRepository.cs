
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
      private readonly String FilePath;

        public DoctorGradeRepository(ICSVStream<DoctorGrade> stream, ISequencer<long> sequencer) : base(stream, sequencer)
        {

        }

        public List<string> GetQuestions()
        {
            String[] questions = File.ReadAllLines("../../ResourceFiles/questionsForDoctorGrade.csv");
            return questions.ToList();
        }
    }
}