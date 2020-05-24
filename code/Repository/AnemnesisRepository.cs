using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
    public class AnemnesisRepository : IAnemenesisRepository
    {
        Anemnesis[] IAnemenesisRepository.createAnemnesis(Anemnesis anemnesis, Examination examination)
        {
            throw new NotImplementedException();
        }
    }
}
