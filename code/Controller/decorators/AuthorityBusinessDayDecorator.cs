using bolnica.Model.Dto;
using Model.Director;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller.decorators
{
    public class AuthorityBusinessDayDecorator : IBusinessDayController
    {
        private IBusinessDayController BusinessDayController;
        private String Role;
        private Dictionary<String, List<String>> AuthorizedUsers;

        public AuthorityBusinessDayDecorator(IBusinessDayController businessDayController, String role)
        {
            this.BusinessDayController = businessDayController;
            this.Role = role;
            AuthorizedUsers = new Dictionary<string, List<string>>();
            AuthorizedUsers["Delete"] = new List<string>() { "Director" };
            AuthorizedUsers["DeletePreviousBusinessDay"] = new List<string>() { "Director" };
            AuthorizedUsers["Edit"] = new List<string>() { "Director" };
            AuthorizedUsers["FreePeriod"] = new List<string>() { "Doctor", "Secretary", "Patient" };
            AuthorizedUsers["Get"] = new List<string>() { "Director", "Doctor" };
            AuthorizedUsers["GetAll"] = new List<string>() { "Director" };
            AuthorizedUsers["GetBusinessDaysByDoctor"] = new List<string>() { "Director" };
            AuthorizedUsers["getDoctorWorkingHoursForSpecificDate"] = new List<string>() { "Director", "Doctor" };
            AuthorizedUsers["GetExactDay"] = new List<string>() { "Doctor", "Secretary", "Patient" };
            AuthorizedUsers["isExaminationPossible"] = new List<string>() { "Secretary" };
            AuthorizedUsers["MarkAsOccupied"] = new List<string>() { "Doctor", "Patient", "Secretary" };
            AuthorizedUsers["Save"] = new List<string>() { "Director" };
            AuthorizedUsers["Search"] = new List<string>() { "Doctor", "Secretary", "Patient" };
            AuthorizedUsers["SetRoomForBusinessDay"] = new List<string>() { "Director" };
            AuthorizedUsers["ChangeDoctorShift"] = new List<string>() { "Director" };
        }

        public Boolean ChangeDoctorShift(BusinessDay newShift)
        {
            if (AuthorizedUsers["ChangeDoctorShift"].SingleOrDefault(any => any.Equals(Role)) != null)
                return BusinessDayController.ChangeDoctorShift(newShift);
            return false;
        }

        public void Delete(BusinessDay entity)
        {
            if (AuthorizedUsers["Delete"].SingleOrDefault(any => any.Equals(Role)) != null)
                BusinessDayController.Delete(entity);
        }


        public void Edit(BusinessDay entity)
        {
            if (AuthorizedUsers["Edit"].SingleOrDefault(any => any.Equals(Role)) != null)
                BusinessDayController.Edit(entity);
        }

        public void FreePeriod(BusinessDay businessDay, List<DateTime> period)
        {
            if (AuthorizedUsers["FreePeriod"].SingleOrDefault(any => any.Equals(Role)) != null)
                BusinessDayController.FreePeriod(businessDay, period);
        }

        public BusinessDay Get(long id)
        {
            if (AuthorizedUsers["Get"].SingleOrDefault(any => any.Equals(Role)) != null)
                return BusinessDayController.Get(id);
            return null;
        }

        public IEnumerable<BusinessDay> GetAll()
        {
            if (AuthorizedUsers["GetAll"].SingleOrDefault(any => any.Equals(Role)) != null)
                return BusinessDayController.GetAll();
            return null;
        }

        public List<BusinessDay> GetBusinessDaysByDoctor(Doctor doctor)
        {
            if (AuthorizedUsers["GetBusinessDaysByDoctor"].SingleOrDefault(any => any.Equals(Role)) != null)
                return BusinessDayController.GetBusinessDaysByDoctor(doctor);
            return null;
        
        }


        public BusinessDay GetExactDay(Doctor doctor, DateTime date)
        {
            if (AuthorizedUsers["GetExactDay"].SingleOrDefault(any => any.Equals(Role)) != null)
                return BusinessDayController.GetExactDay(doctor, date);
            return null;
        }

        public bool isExaminationPossible(Examination examination)
        {
            if (AuthorizedUsers["isExaminationPossible"].SingleOrDefault(any => any.Equals(Role)) != null)
                return BusinessDayController.isExaminationPossible(examination);
            return false;
        }

        public void MarkAsOccupied(List<Period> period, BusinessDay businessDay)
        {
            if (AuthorizedUsers["MarkAsOccupied"].SingleOrDefault(any => any.Equals(Role)) != null)
                BusinessDayController.MarkAsOccupied(period, businessDay);
        }

        public BusinessDay Save(BusinessDay entity)
        {
            if (AuthorizedUsers["Save"].SingleOrDefault(any => any.Equals(Role)) != null)
                return BusinessDayController.Save(entity);
            return null;
        }

        public List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO)
        {
            if (AuthorizedUsers["Search"].SingleOrDefault(any => any.Equals(Role)) != null)
                return BusinessDayController.Search(businessDayDTO);
            return null;
        }


    }
}
