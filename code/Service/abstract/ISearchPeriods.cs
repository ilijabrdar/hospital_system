using bolnica.Model.Dto;
using Controller;
using Model.Dto;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
   public interface ISearchPeriods
{
        List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO, List<BusinessDay> businessDayCollection);
}
}
