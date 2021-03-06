using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterMeal.Data;
using MasterMeal.Models;
using MasterMeal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MasterMeal.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext _context;

        public RecipeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Recipe> GetRecipeByIdAsync(int RecipeId)
        {
            return await _context.Recipe.FirstOrDefaultAsync(r => r.Id == RecipeId);
        }


        public Task<List<Recipe>> GetRecipesByIngredientsAsync(List<Ingredient> ingredients)
        {
            throw new NotImplementedException();
        }


        public async Task<List<Recipe>> GetRecipesByMaxCookingTimeAsync(int maxTime)
        {
            var Recipes = await _context.Recipe
                                    .Include(r => r.Ingredients)
                                    .ThenInclude(i => i.Ingredient)
                                    .Include(r => r.Type)
                                    .Include(r => r.Author)
                                    .Where(r => r.CookingTime <= maxTime).ToListAsync();
            return Recipes;
        }
        public async Task<List<Recipe>> GetRecipesByMinCookingTimeAsync(int minTime)
        {
            var Recipes = await _context.Recipe
                                    .Include(r => r.Ingredients)
                                    .ThenInclude(i => i.Ingredient)
                                    .Include(r => r.Type)
                                    .Include(r => r.Author)
                                    .Where(r => r.CookingTime >= minTime).ToListAsync();
            return Recipes;
        }

        public async Task<List<Recipe>> GetRecipesByRatingAsync(int minRating)
        {
            var Recipes = await _context.Recipe
                                    .Include(r => r.Ingredients)
                                    .ThenInclude(i => i.Ingredient)
                                    .Include(r => r.Type)
                                    .Include(r => r.Author)
                                    .Where(r => r.AvgRating >= minRating).ToListAsync();
            return Recipes;
        }

        public Task<List<Recipe>> GetRecipesBySuppliesAsync(List<Supply> supplies)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Recipe>> GetRecipesByTypeAsync(int typeId)
        {
            var Recipes = await _context.Recipe
                                    .Include(r => r.Ingredients)
                                    .ThenInclude(i => i.Ingredient)
                                    .Include(r => r.Type)
                                    .Include(r => r.Author)
                                    .Where(r => r.TypeId == typeId).ToListAsync();
            return Recipes;
        }

        public Task<List<Recipe>> GetUserFavoriteRecipesAsync(string UserId)
        {

            throw new NotImplementedException();
        }

        public async Task<List<Recipe>> GetUserRecipesAsync(string userId)
        {
            var Recipes = await _context.Recipe
                                    .Include(r => r.Ingredients)
                                    .ThenInclude(i => i.Ingredient)
                                    .Include(r => r.Type)
                                    .Include(r => r.Author)
                                    .Where(r => r.AuthorId == userId).ToListAsync();
            return Recipes;
        }

        public async Task<List<Recipe>> GetUserRecipesByTypeAsync(string userId, int typeId)
        {
            var Recipes = await _context.Recipe
                                    .Include(r => r.Ingredients)
                                    .ThenInclude(i => i.Ingredient)
                                    .Include(r => r.Type)
                                    .Include(r => r.Author)
                                    .Where(r => r.AuthorId == userId && r.TypeId == typeId).ToListAsync();
            return Recipes;
        }

        public async Task<List<Recipe>> GetUserRecipesWithNoRating(string userId)
        {
            var today = DateTime.Now;
            var pastMeals = await _context.Meal.Where(m => m.Date < today && m.ChefId == userId).Include(m => m.Recipe).ThenInclude(r=>r.Ratings).ToListAsync();
            List<Recipe> noRating = new();

            foreach (var meal in pastMeals)
            {
                //if the Recipe doesn't have a rating where this user rated it, add it to the list
                if (meal.Recipe.Ratings.Where(r => r.ChefId == userId) == null)
                {
                    noRating.Add(meal.Recipe);
                }
            }
            return noRating;
        }
    }
}
