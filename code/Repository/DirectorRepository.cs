/***********************************************************************
 * Module:  DirectorService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.DirectorService
 ***********************************************************************/

using Model.Users;
using System;
using bolnica.Repository;
using System.Collections.Generic;

namespace Repository
{
   public class DirectorRepository : CSVRepository<Director, long> ,IDirectorRepository
   {
        public DirectorRepository(ICSVStream<Director> stream, ISequencer<long> sequencer) : base(stream, sequencer) { }

        public Director GetDirectorByUsername(string username) // TODOL Ubaciti ovo u poseban podsloj interfejsa
        {
            IEnumerable<Director> entities = this.GetAll();
            foreach (Director entity in entities)
            {
                if (entity.Username == username)
                    return entity;
            }
            return null;
        }
    }
}