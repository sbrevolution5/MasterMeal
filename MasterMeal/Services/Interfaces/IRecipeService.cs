using MasterMeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services.Interfaces
{
    public interface IRecipeService
    {
        public Task<Recipe> GetRecipieByIdAsync(int recipieId);
        public Task<List<Recipe>> GetUserRecipiesAsync(string userId);
        public Task<List<Recipe>> GetUserRecipiesByTypeAsync(string userId,int typeId);
        public Task<List<Recipe>> GetRecipiesByTypeAsync(int typeId);
        public Task<List<Recipe>> GetRecipiesByRatingAsync(int minRating);
        public Task<List<Recipe>> GetRecipiesByMaxCookingTimeAsync(int maxTime);
        public Task<List<Recipe>> GetRecipiesByMinCookingTimeAsync(int minTime);
        public Task<List<Recipe>> GetUserFavoriteRecipiesAsync(string UserId);
        public Task<List<Recipe>> GetRecipiesByIngredientsAsync(List<Ingredient> ingredients);
        public Task<List<Recipe>> GetRecipiesBySuppliesAsync(List<Supply> supplies);
        public Task<List<Recipe>> GetUserRecipiesWithNoRating(string userId);
    }
}
