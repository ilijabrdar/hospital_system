using bolnica.Service;
using Model.Director;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Service
{
    public class NotifyDoctorBusinessDay
    {
        public Period shift;
        public Room room;

        public NotifyDoctorBusinessDay(Period shift, Room room)
        {
            this.shift = shift;
            this.room = room;
        }
    }
   
   public class NotificationService
   {
        public IDrugService drugService;
        public IBusinessDayService businessDayService;

        public NotificationService(IDrugService drugService, IBusinessDayService businessDayService)
        {
            this.drugService = drugService;
            this.businessDayService = businessDayService;
        }

        public int NotifyDoctorOfDrugsForValidation()
        {
            int ret = 0;
            foreach (Drug drug in drugService.GetAll())
                if (!drug.Approved)
                    ret++;

            return ret;
        }

      public List<NotifyDoctorBusinessDay> NotifyDoctorOfUpcomingBusinessDays(Doctor doctor)
        {
            List<NotifyDoctorBusinessDay> ret = new List<NotifyDoctorBusinessDay>();

            bool day1 = false;
            bool day2 = false;
            bool day3 = false;

            ret.Insert(0, null);
            ret.Insert(1, null);
            ret.Insert(2, null);
            foreach (BusinessDay businessDay in businessDayService.GetBusinessDaysByDoctor(doctor))
            {
                
                if (businessDay.Shift.StartDate.Date == DateTime.Today.Date.AddDays(1).Date)
                {
                    NotifyDoctorBusinessDay notification = new NotifyDoctorBusinessDay(businessDay.Shift, businessDay.room);
                    ret[0]=notification;
                    day1 = true;
                }
                else if (businessDay.Shift.StartDate.Date == DateTime.Today.AddDays(2).Date)
                {
                    NotifyDoctorBusinessDay notification = new NotifyDoctorBusinessDay(businessDay.Shift, businessDay.room);
                    ret[1] = notification;
                    day2 = true;
                }
                else if (businessDay.Shift.StartDate.Date == DateTime.Today.AddDays(3).Date)
                {
                    NotifyDoctorBusinessDay notification = new NotifyDoctorBusinessDay(businessDay.Shift, businessDay.room);
                    ret[2] = notification;
                    day3 = true;   
                }  
            }
            return ret;
        }
    }
}