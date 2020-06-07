// TODO: TAMARA srediti metodeeeeeeeeee
using bolnica.Service;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;

namespace Service
{
    public class ExaminationService : IExaminationService
    { 
        private readonly IExaminationUpcomingRepository _upcomingRepository;
        private readonly IExaminationPreviousRepository _previousRepository;

        public ExaminationService(IExaminationUpcomingRepository upcomingRepository)
        {
            _upcomingRepository = upcomingRepository;
        }

        public ExaminationService(IExaminationPreviousRepository previousRepository)
        {
            _previousRepository = previousRepository;
        }

        public IDiagnosisService _IDiagnosisService;
        public IPrescriptionService _IPrescriptionService;
        public ISymptomService _ISymptomService;
        public ITherapyService _ITherapyService;
        public IReferralService _IReferralService;

        public void Delete(Examination entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Examination entity)
        {
            _upcomingRepository.Edit(entity);
        }

        public Examination Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Examination> GetAll()
        {
            throw new NotImplementedException();
        }

        //public List<Examination> GetExaminationFilter(ExaminationDTO examinationDTO)
        //{
        //    throw new NotImplementedException();
        //}

        public List<Examination> GetFinishedxaminationsByUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<Examination> GetUpcomingExaminationsByUser(User user)
        {
            throw new NotImplementedException();
        }

        public Examination Save(Examination entity)
        {
            throw new NotImplementedException();
        }

        public Examination SaveFinishedExamination(Examination examination)
        {
            throw new NotImplementedException();
        }

        public Examination StartUpcomingExamination(Examination examination)
        {
            throw new NotImplementedException();
        }
    }
}