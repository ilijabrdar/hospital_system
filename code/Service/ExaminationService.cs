/***********************************************************************
 * Module:  ExaminationService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.ExaminationService
 ***********************************************************************/

using bolnica.Service;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class ExaminationService : IExaminationService
    { // TODO srediti oko repozitorijuma 
        private IExaminationUpcomingRepository _upcomingRepository;
        private IExaminationPreviousRepository previousRepository;
        public void Delete(Examination entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Examination entity)
        {
            throw new NotImplementedException();
        }

        public Examination FinishExamination(Examination examination)
        {
            throw new NotImplementedException();
        }

        public Examination Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Examination> GetAll()
        {
            throw new NotImplementedException();
        }

        public Examination[] GetExaminationsByUser(User user)
        {
            throw new NotImplementedException();
        }

        public Examination[] GetSheduledUserExaminations(User user)
        {
            throw new NotImplementedException();
        }

        public Examination Save(Examination entity)
        {
            throw new NotImplementedException();
        }

        public Examination StartScheduledExamination(Examination examination)
        {
            throw new NotImplementedException();
        }
    }
}