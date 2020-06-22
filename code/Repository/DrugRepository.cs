

using bolnica.Repository;
using Model.PatientSecretary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
   public class DrugRepository : CSVRepository<Drug,long>, IDrugRepository, IEagerRepository<Drug,long>
   {
      private String FilePath;
        private readonly IIngredientRepository _ingredientRepository;
        public DrugRepository(ICSVStream<Drug> stream, ISequencer<long> sequencer, IIngredientRepository ingredientRepository)
            : base(stream, sequencer)
        {
            _ingredientRepository = ingredientRepository;
        }

        public IEnumerable<Drug> GetAllEager()
        {
            IEnumerable<Drug> drugs = this.GetAll();
            IEnumerable<Ingredient> ingredients = _ingredientRepository.GetAll();
            BindDrugIngredients(drugs, ingredients);
            BindAlternativeDrugs(drugs);

            return drugs;
        }

        private void BindAlternativeDrugs(IEnumerable<Drug> drugs)
        {
            foreach (Drug drug in drugs.ToList())
            {
                foreach (Drug alternativeDrug in drug.Alternative)
                {
                    Drug temp = base.Get(alternativeDrug.Id);
                    alternativeDrug.Name = temp.Name;
                    alternativeDrug.Amount = temp.Amount;
                    alternativeDrug.Approved = temp.Approved;
                    //other attributes are not important
                }
            }
        }

        private void BindDrugIngredients(IEnumerable<Drug> drugs, IEnumerable<Ingredient> ingredients)
        {
            drugs = drugs.ToList();
            ingredients = ingredients.ToList();
            foreach (Drug drug in drugs)
            {
                foreach(Ingredient ingredient in drug.Ingredients)
                {
                    Ingredient temp = ingredients.SingleOrDefault(ing => ing.GetId() == ingredient.GetId());
                    ingredient.Name = temp.Name;
                    ingredient.Quantity = temp.Quantity;
                }
            }
        }

        public List<Drug> GetAlternativeDrugs(Drug drug)
        {
            //TODO
            throw new NotImplementedException();
        }

        public Drug GetEager(long id)
        {
            Drug drug = base.Get(id);
            foreach (Ingredient ingredient in drug.Ingredients)
            {
                 Ingredient temp = _ingredientRepository.Get(ingredient.Id);
                ingredient.Name = temp.Name;
                ingredient.Quantity = temp.Quantity;
            }

            foreach (Drug alternativeDrug in drug.Alternative)
            {
                Drug temp = base.Get(id);
                alternativeDrug.Name = temp.Name;
                alternativeDrug.Amount = temp.Amount;
                alternativeDrug.Approved = temp.Approved;
                //other attributes are not important
            }

            return drug;
        }

        public List<Drug> GetNotApprovedDrugs()
        {
            List<Drug> notApprovedDrugs = new List<Drug>();
            IEnumerable<Drug> drugs = this.GetAll();
            foreach (Drug drug in drugs.ToList())
            {
                if (drug.Approved == false)
                {
                    notApprovedDrugs.Add(drug);
                }
            }
                return notApprovedDrugs;
        }

    }
}