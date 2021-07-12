using MasterMeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services.Interfaces
{
    public interface IIngredientService
    {
        public Task<Ingredient> GetIngredientByIdAsync(int ingredientId);
        public Task<List<Ingredient>> GetRecipieIngredientsAsync(int recipieId);
        public Task<List<Ingredient>> GetShoppingListIngredientsAsync(int shoppingListId);
    }
}
