using bolnica.Model.Dto;
using Model.Director;
using Model.Dto;
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

        List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO);

        Boolean MarkAsOccupied(Period period, BusinessDay businessDay);

        BusinessDay GetExactDay(Doctor doctor, DateTime date);

        List<BusinessDay> GetBusinessDaysByDoctor(Doctor doctor);

        void DeleteBusinessDayByRoom(Room room);


    }
}
