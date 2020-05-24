/***********************************************************************
 * Module:  RenovationService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.RenovationService
 ***********************************************************************/

using bolnica.Repository;
using Model.Director;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class RenovationRepository : CSVRepository<Renovation,long>, IRenovationRepository
   {
      private String FilePath;

        public RenovationRepository(ICSVStream<Renovation> stream, ISequencer<long> sequencer)
     : base(stream, sequencer)
        {

        }

    }
}