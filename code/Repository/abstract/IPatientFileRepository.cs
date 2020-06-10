

using bolnica.Repository;
using Model.PatientSecretary;
using System;

namespace Repository
{
   public interface IPatientFileRepository : IRepository<PatientFile, long>, IEagerRepository<PatientFile, long>
    {
   }
}