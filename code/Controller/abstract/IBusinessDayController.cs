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
        BusinessDay GetExactDay(Doctor doctor, DateTime date);
        List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO);
        void MarkAsOccupied(List<Period> period, BusinessDay businessDay);
        List<BusinessDay> GetBusinessDaysByDoctor(Doctor doctor);
        void FreePeriod(BusinessDay businessDay, List<DateTime> period);
        Boolean isExaminationPossible(Examination examination);
        Boolean ChangeDoctorShift(BusinessDay newShift);
    }
}
