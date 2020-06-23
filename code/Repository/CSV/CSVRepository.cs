using bolnica.Repository.CSV;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using System.Xml;

namespace bolnica.Repository
{
    public class CSVRepository<E, ID> : CSVGetterRepository<E, ID> ,IRepository<E, ID>
        where E : IIdentifiable<ID>
        where ID : IComparable
    {
        public CSVRepository(ICSVStream<E> stream, ISequencer<ID> sequencer) : base(stream, sequencer) {}

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

        public E Save(E entity)
        {
            entity.SetId(_sequencer.GenerateId());
            _stream.AppendToFile(entity);
            return entity;
        }

    }


    
}
