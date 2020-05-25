/***********************************************************************
 * Module:  IIngredientRepository.cs
 * Author:  Asus
 * Purpose: Definition of the Interface Repository.IIngredientRepository
 ***********************************************************************/

using bolnica.Repository;
using Model.PatientSecretary;
using System;

namespace Repository
{
   public interface IIngredientRepository : IRepository<Ingredient,long>, IGetterRepository<Ingredient, long>
   {
   }
}