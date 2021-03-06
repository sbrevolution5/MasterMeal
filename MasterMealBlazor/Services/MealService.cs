using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterMealBlazor.Data;
using MasterMealBlazor.Models;
using MasterMealBlazor.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MasterMealBlazor.Services
{
    public class MealService : IMealService
    {
        private readonly ApplicationDbContext _context;

        public MealService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Meal>> GetUserFutureMealsAsync(string chefId)
        {
            var now = DateTime.Now;
            var futureMeals = await _context.Meal.Where(m => m.ChefId == chefId)
                                .Where(m => m.Date >= now)
                                .Include(m => m.Recipe)
                                .ThenInclude(r => r.Ingredients)
                                .ThenInclude(i => i.Ingredient)
                                .Include(m => m.Recipe)
                                .ThenInclude(r => r.Supplies)
                                .ToListAsync();

            return futureMeals;
        }

        public async Task<List<Meal>> GetUserMealsAsync(string chefId)
        {
            var userMeals = await _context.Meal.Where(m => m.ChefId == chefId)
                                .Include(m => m.Recipe)
                                .ThenInclude(r => r.Ingredients)
                                .ThenInclude(i => i.Ingredient)
                                .Include(m => m.Recipe)
                                .ThenInclude(r => r.Supplies)
                                .ToListAsync();

            return userMeals;
        }

        public async Task<List<Meal>> GetUserMealsInDateRangeAsync(string chefId, DateTime minDateInclusive, DateTime maxDateInclusive)
        {
            var futureMeals = await _context.Meal.Where(m => m.ChefId == chefId)
                                .Where(m => m.Date >= minDateInclusive && m.Date <= maxDateInclusive)
                                .Include(m => m.Recipe)
                                .ThenInclude(r => r.Ingredients)
                                .ThenInclude(i => i.Ingredient)
                                .Include(m => m.Recipe)
                                .ThenInclude(r => r.Supplies)
                                .ToListAsync();

            return futureMeals;
        }
    }
}
