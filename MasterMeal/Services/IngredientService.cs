using MasterMeal.Models;
using MasterMeal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services
{
    public class IngredientService : IIngredientService
    {
        public Task<Ingredient> GetIngredientByIdAsync(int ingredientId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ingredient>> GetRecipieIngredientsAsync(int recipieId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Ingredient>> GetShoppingListIngredientsAsync(int shoppingListId)
        {
            throw new NotImplementedException();
        }
    }
}
