using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;

namespace bolnica.Repository.CSV
{
    public class CSVGetterRepository<E, ID> : IGetterRepository<E, ID>
        where E : IIdentifiable<ID>
        where ID : IComparable
    {
        protected ICSVStream<E> _stream;
        protected ISequencer<ID> _sequencer;

        public CSVGetterRepository(ICSVStream<E> stream, ISequencer<ID> sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }

        public E get(ID id)
        {
            try
            {
                return _stream
                   .ReadAll()
                   .SingleOrDefault(entity => entity.GetId().CompareTo(id) == 0);
            }
            catch
            {
                Console.WriteLine("Nije pronasao ni jedan entitet sa zadatim id");
                return default(E);
            }
        }

        public IEnumerable<E> GetAll()
        {
            return _stream.ReadAll();
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private ID GetMaxId(IEnumerable<E> entities)
           => entities.Count() == 0 ? default : entities.Max(entity => entity.GetId());
    }
}
