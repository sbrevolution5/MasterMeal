using MasterMeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services.Interfaces
{
    public interface IRatingService
    {
        public Task<List<Rating>> GetRatingsByUserAsync(string userId);
        public Task<List<Rating>> GetRatingsByRecipieAsync(int recipieId);
    }
}
