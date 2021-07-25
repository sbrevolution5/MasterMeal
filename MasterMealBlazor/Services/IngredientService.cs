using MasterMealBlazor.Data;
using MasterMealBlazor.Models;
using MasterMealBlazor.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMealBlazor.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly ApplicationDbContext _context;

        public IngredientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Ingredient> GetIngredientByIdAsync(int ingredientId)
        {
            var ingredient = await _context.Ingredient.FirstOrDefaultAsync(i => i.Id == ingredientId);
            return ingredient;
        }

        public Task<List<Ingredient>> GetRecipeIngredientsAsync(int RecipeId)
        {

            throw new NotImplementedException();
        }

        public Task<List<Ingredient>> GetShoppingListIngredientsAsync(int shoppingListId)
        {
            throw new NotImplementedException();
        }
    }
}
