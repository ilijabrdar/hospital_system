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
        public DateTime day;
        public Room room;

        public NotifyDoctorBusinessDay(Period shift, DateTime day, Room room)
        {
            this.shift = shift;
            this.day = day;
            this.room = room;
        }
    }

        
   public class NotificationService
   {
        //kako doktor radi naredna tri dana
        //izmena termina
        //broj lekova za validaciju

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
            int days_ahead = 1;

            foreach (BusinessDay businessDay in businessDayService.GetBusinessDaysByDoctor(doctor))
            {
               if (checkBelonging(businessDay))
                {
                    if (DateTime.Compare(businessDay.Shift.EndDate.Date, DateTime.Now.AddDays(1).Date) >= 0 && days_ahead!=4)
                    {
                        NotifyDoctorBusinessDay notification = new NotifyDoctorBusinessDay(businessDay.Shift, DateTime.Now.AddDays(days_ahead++), businessDay.room);
                        ret.Add(notification);
                    }
                    if (DateTime.Compare(businessDay.Shift.EndDate.Date, DateTime.Now.AddDays(2).Date) >= 0 && days_ahead != 4)
                    {
                        NotifyDoctorBusinessDay notification = new NotifyDoctorBusinessDay(businessDay.Shift, DateTime.Now.AddDays(days_ahead++), businessDay.room);
                        ret.Add(notification);
                    }
                    if (DateTime.Compare(businessDay.Shift.EndDate.Date, DateTime.Now.AddDays(3).Date) >= 0 && days_ahead != 4)
                    {
                        NotifyDoctorBusinessDay notification = new NotifyDoctorBusinessDay(businessDay.Shift, DateTime.Now.AddDays(days_ahead++), businessDay.room);
                        ret.Add(notification);
                    }


                    if (ret.Count == 4)
                        break;
                }
            }

            return ret;
        }

        private bool checkBelonging(BusinessDay businessDay)
        {
            return ((DateTime.Compare(businessDay.Shift.StartDate.Date, DateTime.Now.AddDays(1).Date) <= 0 || DateTime.Compare(businessDay.Shift.StartDate.Date, DateTime.Now.AddDays(2).Date) <= 0 || DateTime.Compare(businessDay.Shift.StartDate.Date, DateTime.Now.AddDays(3).Date) <= 0) 
                && (DateTime.Compare(businessDay.Shift.EndDate.Date, DateTime.Now.AddDays(1).Date) >= 0 || DateTime.Compare(businessDay.Shift.EndDate.Date, DateTime.Now.AddDays(2).Date) >= 0 || DateTime.Compare(businessDay.Shift.EndDate.Date, DateTime.Now.AddDays(3).Date) >= 0));
        }
    }
}