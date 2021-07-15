using MasterMeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services.Interfaces
{
    public interface IRecipieService
    {
        public Task<Recipie> GetRecipieByIdAsync(int recipieId);
        public Task<List<Recipie>> GetUserRecipiesAsync(string userId);
        public Task<List<Recipie>> GetUserRecipiesByTypeAsync(string userId,int typeId);
        public Task<List<Recipie>> GetRecipiesByTypeAsync(int typeId);
        public Task<List<Recipie>> GetRecipiesByRatingAsync(int minRating);
        public Task<List<Recipie>> GetRecipiesByMaxCookingTimeAsync(int maxTime);
        public Task<List<Recipie>> GetRecipiesByMinCookingTimeAsync(int minTime);
        public Task<List<Recipie>> GetUserFavoriteRecipiesAsync(string UserId);
        public Task<List<Recipie>> GetRecipiesByIngredientsAsync(List<Ingredient> ingredients);
        public Task<List<Recipie>> GetRecipiesBySuppliesAsync(List<Supply> supplies);
        public Task<List<Recipie>> GetUserRecipiesWithNoRating(string userId);
    }
}
