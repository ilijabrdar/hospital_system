using Model.PatientSecretary;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bolnica.Repository
{
   public interface IPrescriptionRepository : IRepository<Prescription,long>
    {
    }
}
