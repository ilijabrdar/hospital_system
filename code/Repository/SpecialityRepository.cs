using bolnica.Repository;
using bolnica.Repository.CSV;
using Model.Doctor;
using System;
using System.Collections.Generic;

namespace Repository
{
    public class SpecialityRepository : CSVGetterRepository<Speciality, long>, ISpecialityRepository
    {
        public SpecialityRepository(ICSVStream<Speciality> stream, ISequencer<long> sequencer)
               : base(stream, sequencer)
        {

        }
    }
}