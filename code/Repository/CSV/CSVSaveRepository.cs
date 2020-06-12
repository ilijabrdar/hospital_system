using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;

namespace bolnica.Repository.CSV
{

    class CSVSaveRepository<E, ID> : ISaveRepository<E, ID>
    where E : IIdentifiable<ID>
    where ID : IComparable
    {
        public E Save(E entity)
        {
            entity.SetId(_sequencer.GenerateId());
            _stream.AppendToFile(entity);
            return entity;
        }
    }
}
