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
   public class SpecialityRepository : CSVRepository<Speciality,long>, ISpecialityRepository , IGetterRepository<Speciality,long>
   {
      private String FilePath;
        public SpecialityRepository(ICSVStream<Speciality> stream, ISequencer<long> sequencer) : base(stream, sequencer)
        {

        }

        public Speciality CreateSpeciality(Speciality speciality)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSpeciality(Speciality speciality)
        {
            throw new NotImplementedException();
        }
    }
}