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
            //this.day = day;
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
            //int days_ahead = 1;

            bool day1 = false;
            bool day2 = false;
            bool day3 = false;


            foreach (BusinessDay businessDay in businessDayService.GetBusinessDaysByDoctor(doctor))
            {
                //if (checkBelonging(businessDay))
                // {
                //     if (DateTime.Compare(businessDay.Shift.EndDate.Date, DateTime.Now.AddDays(1).Date) >= 0 && days_ahead!=4)
                //     {
                //         NotifyDoctorBusinessDay notification = new NotifyDoctorBusinessDay(businessDay.Shift, DateTime.Now.AddDays(days_ahead++), businessDay.room);
                //         ret.Add(notification);
                //     }
                //     if (DateTime.Compare(businessDay.Shift.EndDate.Date, DateTime.Now.AddDays(2).Date) >= 0 && days_ahead != 4)
                //     {
                //         NotifyDoctorBusinessDay notification = new NotifyDoctorBusinessDay(businessDay.Shift, DateTime.Now.AddDays(days_ahead++), businessDay.room);
                //         ret.Add(notification);
                //     }
                //     if (DateTime.Compare(businessDay.Shift.EndDate.Date, DateTime.Now.AddDays(3).Date) >= 0 && days_ahead != 4)
                //     {
                //         NotifyDoctorBusinessDay notification = new NotifyDoctorBusinessDay(businessDay.Shift, DateTime.Now.AddDays(days_ahead++), businessDay.room);
                //         ret.Add(notification);
                //     }

                //     if (ret.Count == 4)
                //         break;
                // }

                if (businessDay.Shift.StartDate.Date == DateTime.Today.Date.AddDays(1).Date)
                {
                    NotifyDoctorBusinessDay notification = new NotifyDoctorBusinessDay(businessDay.Shift, businessDay.room);
                    ret.Insert(0, notification);
                    day1 = true;
                }
                else if (businessDay.Shift.StartDate.Date == DateTime.Today.AddDays(2).Date)
                {
                    NotifyDoctorBusinessDay notification = new NotifyDoctorBusinessDay(businessDay.Shift, businessDay.room);
                    ret.Insert(1, notification);
                    day2 = true;
                }
                else if (businessDay.Shift.StartDate.Date == DateTime.Today.AddDays(3).Date)
                {
                    NotifyDoctorBusinessDay notification = new NotifyDoctorBusinessDay(businessDay.Shift, businessDay.room);
                    ret.Insert(2, notification);
                    day3 = true;                }
            }

            if (!day1)
                ret.Insert(0, null);
            if (!day2)
                ret.Insert(1, null);
            if (!day3)
                ret.Insert(2, null);



            return ret;
        }

        //private bool checkBelonging(BusinessDay businessDay)
        //{
        //    return ((DateTime.Compare(businessDay.Shift.StartDate.Date, DateTime.Now.AddDays(1).Date) <= 0 || DateTime.Compare(businessDay.Shift.StartDate.Date, DateTime.Now.AddDays(2).Date) <= 0 || DateTime.Compare(businessDay.Shift.StartDate.Date, DateTime.Now.AddDays(3).Date) <= 0) 
        //        && (DateTime.Compare(businessDay.Shift.EndDate.Date, DateTime.Now.AddDays(1).Date) >= 0 || DateTime.Compare(businessDay.Shift.EndDate.Date, DateTime.Now.AddDays(2).Date) >= 0 || DateTime.Compare(businessDay.Shift.EndDate.Date, DateTime.Now.AddDays(3).Date) >= 0));
        //}
    }
}