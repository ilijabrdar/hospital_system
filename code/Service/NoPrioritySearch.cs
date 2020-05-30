using bolnica.Model.Dto;
using Model.Dto;
using Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Service
{
   public class NoPrioritySearch : ISearchPeriods
    {
        public NoPrioritySearch() { }

        public List<ExaminationDTO> Search(BusinessDayDTO businessDayDTO, List<BusinessDay> businessDayCollection)
        {
            throw new NotImplementedException();
        }
    }
}
