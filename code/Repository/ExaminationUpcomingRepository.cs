/***********************************************************************
 * Module:  ExaminationService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ExaminationService
 ***********************************************************************/

using bolnica.Repository;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class ExaminationUpcomingRepository : CSVRepository<Examination, long>, IExaminationUpcomingRepository
    {
        public ExaminationUpcomingRepository(ICSVStream<Examination> stream, ISequencer<long> sequencer)
  : base(stream, sequencer)
        {

        }
        List<Examination> IExaminationUpcomingRepository.GetScheduledUserExaminations(User user)
        {
            throw new NotImplementedException();
        }

        Examination IRepository<Examination, long>.Save(Examination entity)
        {
            throw new NotImplementedException();
        }

        Examination IExaminationUpcomingRepository.StartUpcomingExamination(Examination examination)
        {
            throw new NotImplementedException();
        }
    }
}