using Controller;
using Model.Director;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Controller
{
   public interface IBusinessDayController : IController<BusinessDay, long>
    {

         Boolean DeletePreviousBusinessDay();

         Boolean SetRoomForBusinessDay(BusinessDay businessDay, Room room);

         List<Period> GenerateAvailablePeriods(BusinessDay bussinesDay);

        Boolean MarkAsOccupied(Period period, BusinessDay businessDay);

        List<Examination> PeriodRecommendationByDate(DateTime date);

         List<BusinessDay> GetBusinessDaysByDoctor(Doctor doctor);
    }
}
