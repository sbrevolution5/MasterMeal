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
    public class RecipieService : IRecipieService
    {
        private readonly ApplicationDbContext _context;

        public RecipieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Recipie> GetRecipieByIdAsync(int recipieId)
        {
            return await _context.Recipie.FirstOrDefaultAsync(r => r.Id == recipieId);
        }


        public Task<List<Recipie>> GetRecipiesByIngredientsAsync(List<Ingredient> ingredients)
        {
            throw new NotImplementedException();
        }


        public async Task<List<Recipie>> GetRecipiesByMaxCookingTimeAsync(int maxTime)
        {
            var recipies = await _context.Recipie
                                    .Include(r => r.Ingredients)
                                    .ThenInclude(i => i.Ingredient)
                                    .Include(r => r.Type)
                                    .Include(r => r.Author)
                                    .Where(r => r.CookingTime <= maxTime).ToListAsync();
            return recipies;
        }
        public async Task<List<Recipie>> GetRecipiesByMinCookingTimeAsync(int minTime)
        {
            var recipies = await _context.Recipie
                                    .Include(r => r.Ingredients)
                                    .ThenInclude(i => i.Ingredient)
                                    .Include(r => r.Type)
                                    .Include(r => r.Author)
                                    .Where(r => r.CookingTime >= minTime).ToListAsync();
            return recipies;
        }

        public Task<List<Recipie>> GetRecipiesByRatingAsync(int minRating)
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipie>> GetRecipiesBySuppliesAsync(List<Supply> supplies)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Recipie>> GetRecipiesByTypeAsync(int typeId)
        {
            var recipies = await _context.Recipie
                                    .Include(r => r.Ingredients)
                                    .ThenInclude(i => i.Ingredient)
                                    .Include(r => r.Type)
                                    .Include(r => r.Author)
                                    .Where(r => r.TypeId == typeId).ToListAsync();
            return recipies;
        }

        public Task<List<Recipie>> GetUserFavoriteRecipiesAsync(string UserId)
        {

            throw new NotImplementedException();
        }

        public async Task<List<Recipie>> GetUserRecipiesAsync(string userId)
        {
            var recipies = await _context.Recipie
                                    .Include(r => r.Ingredients)
                                    .ThenInclude(i => i.Ingredient)
                                    .Include(r => r.Type)
                                    .Include(r => r.Author)
                                    .Where(r => r.AuthorId == userId).ToListAsync();
            return recipies;
        }

        public async Task<List<Recipie>> GetUserRecipiesByTypeAsync(string userId, int typeId)
        {
            var recipies = await _context.Recipie
                                    .Include(r => r.Ingredients)
                                    .ThenInclude(i => i.Ingredient)
                                    .Include(r => r.Type)
                                    .Include(r => r.Author)
                                    .Where(r => r.AuthorId == userId && r.TypeId == typeId).ToListAsync();
            return recipies;
        }

        public Task<List<Recipie>> GetUserRecipiesWithNoRating(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
