using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using System.Xml;

namespace bolnica.Repository
{
    public class CSVRepository<E, ID> : IRepository<E, ID>
        where E : IIdentifiable<ID>
        where ID : IComparable
    {
        protected ICSVStream<E> _stream;
        protected ISequencer<ID> _sequencer;

        public CSVRepository(ICSVStream<E> stream, ISequencer<ID> sequencer)
        {
            _stream = stream;
            _sequencer = sequencer;
            InitializeId();
        }

        public void Delete(E entity)
        {
            try
            {
                var entities = _stream.ReadAll().ToList();
                var entityToRemove = entities.SingleOrDefault(ent => ent.GetId().CompareTo(entity.GetId()) == 0);
                entities.Remove(entityToRemove);
                _stream.SaveAll(entities);
               
            } catch
            {
                Console.WriteLine("Nije pronasao trazeni entitet sa id:" + entity.GetId());
            }
        }

        public void Edit(E entity)
        {
            try
            {
                var entities = _stream.ReadAll().ToList();
                entities[entities.FindIndex(ent => ent.GetId().CompareTo(entity.GetId()) == 0)] = entity;
                _stream.SaveAll(entities);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Nije pronasao entitet sa id=" + entity.GetId());
            }
        }

        public E Get(ID id)
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

        public E Save(E entity)
        {
            entity.SetId(_sequencer.GenerateId());
            _stream.AppendToFile(entity);
            return entity;
        }

        protected void InitializeId() => _sequencer.Initialize(GetMaxId(_stream.ReadAll()));

        private ID GetMaxId(IEnumerable<E> entities)
           => entities.Count() == 0 ? default : entities.Max(entity => entity.GetId());

    }


    
}
