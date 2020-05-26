using Model.Director;
using Model.PatientSecretary;
using Model.Users;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
    public interface IBusinessDayService : IService<BusinessDay, long>
    {

        Boolean DeletePreviousBusinessDay();

        Boolean SetRoomForBusinessDay(BusinessDay businessDay, Room room);

        List<Period> GenerateAvailablePeriods(BusinessDay bussinesDay);

        Boolean MarkAsOccupied(Period period, BusinessDay businessDay);

        List<Examination> PeriodRecommendationByDate(DateTime date);

        List<BusinessDay> GetBusinessDaysByDoctor(Doctor doctor);

    }
}
