/***********************************************************************
 * Module:  SpecialityService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.SpecialityService
 ***********************************************************************/

using bolnica.Repository;
using Model.Doctor;
using System;

namespace Repository
{
   public class SpecialityRepository : CSVRepository<Specialty,long>, ISpecialityRepository , IGetterRepository<Specialty,long>
   {
      private String FilePath;
        public SpecialityRepository(ICSVStream<Specialty> stream, ISequencer<long> sequencer) : base(stream, sequencer)
        {

        }

        public Specialty CreateSpeciality(Specialty speciality)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSpeciality(Specialty speciality)
        {
            throw new NotImplementedException();
        }
    }
}