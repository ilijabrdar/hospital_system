using bolnica.Model.Dto;
using Controller;
using Model.Director;
using Model.Dto;
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


        List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO);

        Boolean MarkAsOccupied(Period period, BusinessDay businessDay);

        BusinessDay getDoctorWorkingHoursForSpecificDate(Doctor doctor, DateTime date);

         List<BusinessDay> GetBusinessDaysByDoctor(Doctor doctor);
    }
}
