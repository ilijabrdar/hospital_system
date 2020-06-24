using bolnica.Repository;
using bolnica.Repository.CSV;
using Model.PatientSecretary;
using System;

namespace Repository
{
   public class IngredientRepository : CSVRepository<Ingredient,long>, IIngredientRepository
   {
        public IngredientRepository(ICSVStream<Ingredient> stream, ISequencer<long> sequencer)
            : base(stream, sequencer)
        {

        }

    }
}