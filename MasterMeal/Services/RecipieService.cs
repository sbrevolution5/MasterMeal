using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterMeal.Data;
using MasterMeal.Models;
using MasterMeal.Services.Interfaces;

namespace MasterMeal.Services
{
    public class RecipieService : IRecipieService
    {
        private readonly ApplicationDbContext _context;

        public RecipieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Recipie> GetRecipieByIdAsync(int recipieId)
        {
            throw new NotImplementedException();
        }


        public Task<List<Recipie>> GetRecipiesByIngredientsAsync(List<Ingredient> ingredients)
        {
            throw new NotImplementedException();
        }


        public Task<List<Recipie>> GetRecipiesByMaxCookingTimeAsync(int maxTime)
        {
            throw new NotImplementedException();
        }
        public Task<List<Recipie>> GetRecipiesByMinCookingTimeAsync(int minTime)
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipie>> GetRecipiesByRatingAsync(int minRating)
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipie>> GetRecipiesBySuppliesAsync(List<Supply> supplies)
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipie>> GetRecipiesByTypeAsync(int typeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipie>> GetUserFavoriteRecipiesAsync(string UserId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipie>> GetUserRecipiesAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipie>> GetUserRecipiesByTypeAsync(string userId, int typeId)
        {
            throw new NotImplementedException();
        }
    }
}
