using bolnica.Repository;
using bolnica.Service;
using Model.Director;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class ExaminationService : IExaminationService
    { 
        private readonly IExaminationUpcomingRepository _upcomingRepository;
        private readonly IExaminationPreviousRepository _previousRepository;
        public IDiagnosisService _diagnosisService { get; set; }
        public IPrescriptionService _prescriptionService { get; set; }
        public IReferralService _referralService { get; set; }
        public ISymptomService _symptomService { get; set; }
        public ITherapyService _therapyService { get; set; }

        public ExaminationService(IExaminationUpcomingRepository upcomingRepository, IExaminationPreviousRepository previousRepository, IDiagnosisService diagnosisService, IPrescriptionService prescriptionService, IReferralService referralService, ISymptomService symptomService, ITherapyService therapyService)
        {
            _upcomingRepository = upcomingRepository;
            _previousRepository = previousRepository;
            _diagnosisService = diagnosisService;
            _prescriptionService = prescriptionService;
            _referralService = referralService;
            _symptomService = symptomService;
            _therapyService = therapyService;
        }

        public ExaminationService(IExaminationUpcomingRepository upcomingRepository, IExaminationPreviousRepository previousRepository)
        {
            _upcomingRepository = upcomingRepository;
            _previousRepository = previousRepository;
        }

        public void Delete(Examination entity)
        {
            _upcomingRepository.Delete(entity);
        }

        public void Edit(Examination entity)
        {
            _upcomingRepository.Edit(entity);
        }

        public List<Examination> GetFinishedxaminationsByUser(User user)
        {
            return _previousRepository.GetExaminationsByUser(user);
        }

        public Examination Save(Examination entity)
        {
            return _upcomingRepository.Save(entity);
        }

        public Examination SaveFinishedExamination(Examination examination)
        {
            return _previousRepository.Save(examination);
        }

        public List<Examination> GetUpcomingExaminationsByUser(User user)
        {
            return _upcomingRepository.GetUpcomingExaminationsByUser(user);
        }

        public List<Examination> GetUpcomingExaminationsByRoomAndPeriod(Room room, Period period)
        {
            List<Examination> examinations = new List<Examination>();
            foreach (Examination examination in GetAll())
                if (DateTime.Compare(examination.Period.StartDate.Date, period.StartDate.Date) >= 0 && DateTime.Compare(examination.Period.EndDate.Date, period.EndDate.Date) <= 0 && getExaminationRoom(examination).Id == room.Id)
                        examinations.Add(examination);

            return examinations;
        }

        public List<Examination> GetPreviousExaminationsByRoomAndPeriod(Room room, Period period)
        {
            List<Examination> examinations = new List<Examination>();
            foreach (Examination examination in GetAllPrevious())
                if (DateTime.Compare(examination.Period.StartDate.Date, period.StartDate.Date) >= 0 && DateTime.Compare(examination.Period.EndDate.Date, period.EndDate.Date) <= 0 && getExaminationRoom(examination).Id == room.Id)
                    examinations.Add(examination);

            return examinations;
        }

        public Examination Get(long id)
        {

            return _upcomingRepository.Get(id);
        }

        public IEnumerable<Examination> GetAll()
        {
            return _upcomingRepository.GetAllEager();
        }

        public IEnumerable<Examination> GetAllPrevious()
        {
            return _previousRepository.GetAllEager();
        }

        public List<Examination> GetExaminationsByFilter(ExaminationDTO examinationDTO, Boolean upcomingOnly)
        {
            List<Examination> examinations = GetAll().ToList();
            if (!upcomingOnly)
                examinations.AddRange(GetAllPrevious());

            for(int i = 0; i < examinations.Count; i++)
            {

                if (examinationDTO.Doctor != null && examinations[i].Doctor.FullName != examinationDTO.Doctor.FullName)
                {
                    examinations.RemoveAt(i);
                    i--;
                    continue;
                }

                if (examinationDTO.Patient != null && examinations[i].User.FullName != examinationDTO.Patient.FullName)
                {
                    examinations.RemoveAt(i);
                    i--;
                    continue;
                }

                if (examinationDTO.Period.StartDate > examinations[i].Period.StartDate || examinationDTO.Period.EndDate < examinations[i].Period.StartDate)
                {
                    examinations.RemoveAt(i);
                    i--;
                    continue;
                }

                if(examinationDTO.Room != null && getExaminationRoom(examinations[i]).RoomCode != examinationDTO.Room.RoomCode)
                {
                    examinations.RemoveAt(i);
                    i--;
                    continue;
                }
            }
            return examinations;
        }

        public Room getExaminationRoom(Examination examination)
        {
            Room room = null;
            foreach (BusinessDay businessDay in examination.Doctor.BusinessDay)
                if (businessDay.Shift.StartDate.Date == examination.Period.StartDate.Date)
                {
                    room = businessDay.room;
                    break;
                }
            return room;
        }

    }
}