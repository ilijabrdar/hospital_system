/***********************************************************************
 * Module:  HospitalizationService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.HospitalizationService
 ***********************************************************************/

using bolnica.Repository;
using Model.Doctor;
using System;

namespace Repository
{
   public class HospitalizationRepository : CSVRepository<Hospitalization, long>, IHospitalizationRepository
    {
      private String FilePath;
        public HospitalizationRepository(ICSVStream<Hospitalization> stream, ISequencer<long> sequencer)
            : base(stream, sequencer)
        {

        }

    }
}