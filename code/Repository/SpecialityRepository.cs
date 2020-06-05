/***********************************************************************
 * Module:  SpecialityService.cs
 * Author:  Asus
 * Purpose: Definition of the Class Service.SpecialityService
 ***********************************************************************/

using bolnica.Repository;
using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Repository
{

    public class SpecialityRepository : CSVRepository<Speciality, long>, ISpecialityRepository
    {
        public SpecialityRepository(ICSVStream<Speciality> stream, ISequencer<long> sequencer)
               : base(stream, sequencer)
        {

        }
    }
}