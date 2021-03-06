using MasterMealBlazor.Data;
using MasterMealBlazor.Models;
using MasterMealBlazor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMealBlazor.Services
{
    public class SupplyService : ISupplyService
    {
        private readonly ApplicationDbContext _context;

        public SupplyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Supply>> GetSuppliesForMultipleRecipesAsync(List<Recipe> Recipes)
        {
            throw new NotImplementedException();
        }

        public Task<List<Supply>> GetSuppliesForRecipeAsync(int RecipeId)
        {
            throw new NotImplementedException();
        }

        public Task<Supply> GetSupplyByIdAsync(int supplyId)
        {
            throw new NotImplementedException();
        }
    }
}
