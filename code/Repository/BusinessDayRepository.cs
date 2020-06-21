 using bolnica.Repository;
using Model.Director;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class BusinessDayRepository : CSVRepository<BusinessDay,long>, IBusinessDayRepository
   {

      private String FilePath;
        public  IDoctorRepository doctorRepo;
        private readonly IRoomRepository roomRepo;
        public BusinessDayRepository(ICSVStream<BusinessDay> stream, ISequencer<long> sequencer, IRoomRepository room)
           : base(stream, sequencer)
        { 
            roomRepo = room;
        }

        public IEnumerable<BusinessDay> GetAllEager()
        {
            List<BusinessDay> businessDays = new List<BusinessDay>();
            foreach(BusinessDay day in GetAll().ToList())
            {
                businessDays.Add(GetEager(day.GetId()));
            }

            return businessDays;
        }

        public List<BusinessDay> GetBusinessDaysByDate(DateTime date)
        {
           
            List<BusinessDay> businessDays = GetAllEager().ToList();
            List<BusinessDay> retVal = new List<BusinessDay>();
                foreach (BusinessDay day in businessDays)
                {
                    if (day.Shift.StartDate.Date == date.Date)
                        retVal.Add(day);
                }

            return retVal;
        }

        public BusinessDay GetEager(long id)
        {
            BusinessDay businessDay = Get(id);
            businessDay.doctor = doctorRepo.Get(businessDay.doctor.GetId());
            businessDay.room = roomRepo.GetEager(businessDay.room.GetId());
            return businessDay;
        }

        public bool SetRoomForBusinessDay(BusinessDay businessDay, Room room)
        {
            throw new NotImplementedException();
        }
    }
}