using bolnica.Repository;
using Model.Doctor;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IHospitalizationRepository : IRepository<Hospitalization, long>, IEagerRepository<Hospitalization, long>
   {
        List<Hospitalization> GetHospitalizationByDoctor(Doctor doctor);

    }
}