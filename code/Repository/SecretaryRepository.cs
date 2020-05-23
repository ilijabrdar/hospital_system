/***********************************************************************
 * Module:  SecretaryService.cs
 * Author:  david
 * Purpose: Definition of the Class Service.SecretaryService
 ***********************************************************************/

using bolnica.Repository;
using Model.Users;
using System;
using System.Collections.Generic;

namespace Repository
{
   public class SecretaryRepository : CSVRepository<Secretary, long>, ISecretaryRepository
   {

        public SecretaryRepository(ICSVStream<Secretary> stream, ISequencer<long> sequencer) : base(stream, sequencer)
        {

        }

        public Secretary GetSecretaryByUsername(string username)
        {
            IEnumerable<Secretary> entities = this.GetAll();
            foreach(Secretary entity in entities)
            {
                if (entity.Username == username)
                    return entity;
            }
            return null;
        }
    }
}