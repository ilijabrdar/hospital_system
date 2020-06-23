using bolnica.Repository;
using Model.Doctor;
using System;

namespace Repository
{
   public interface IHospitalizationRepository : IRepository<Hospitalization, long>, IEagerRepository<Hospitalization, long>
   {
   }
}