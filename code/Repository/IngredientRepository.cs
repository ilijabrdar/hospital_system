/***********************************************************************
 * Module:  IngredientRepository.cs
 * Author:  david
 * Purpose: Definition of the Class Repository.IngredientRepository
 ***********************************************************************/

using bolnica.Repository;
using Model.PatientSecretary;
using System;

namespace Repository
{
   public class IngredientRepository : CSVRepository<Ingredient,long>, IIngredientRepository
   {
      private String FilePath;

        private const string ENTITY_NAME = "Ingredient";

        public IngredientRepository(ICSVStream<Ingredient> stream, ISequencer<long> sequencer)
            : base(ENTITY_NAME, stream, sequencer)
        {

        }

    }
}