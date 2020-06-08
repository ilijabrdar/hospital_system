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
    public class ExaminationPreviousRepository : CSVRepository<Examination, long>, IExaminationPreviousRepository
    {
        public ExaminationPreviousRepository(ICSVStream<Examination> stream, ISequencer<long> sequencer)
  : base(stream, sequencer)
        {

        }
        List<Examination> IExaminationPreviousRepository.GetExaminationsByUser(User user)
        {
            throw new NotImplementedException();
        }

    }
}