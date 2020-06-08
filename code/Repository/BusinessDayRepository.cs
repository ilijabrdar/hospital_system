/***********************************************************************
 * Module:  BusinessDayService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.BusinessDayService
 ***********************************************************************/

using bolnica.Repository;
using Model.Director;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class BusinessDayRepository : CSVRepository<BusinessDay,long>, IBusinessDayRepository, IEagerRepository<BusinessDay,long>
   {
      private String FilePath;
        private readonly IDoctorRepository doctorRepo;
        private readonly IRoomRepository roomRepo;
        public BusinessDayRepository(ICSVStream<BusinessDay> stream, ISequencer<long> sequencer, IDoctorRepository doctor, IRoomRepository room)
           : base(stream, sequencer)
        {
            doctorRepo = doctor;
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
            throw new NotImplementedException();
        }

        public BusinessDay GetEager(long id)
        {
            BusinessDay businessDay = Get(id);
            businessDay.doctor = doctorRepo.Get(businessDay.doctor.GetId());
            businessDay.room = roomRepo.Get(businessDay.room.GetId());
            return businessDay;
        }

        public bool SetRoomForBusinessDay(BusinessDay businessDay, Room room)
        {
            throw new NotImplementedException();
        }
    }
}