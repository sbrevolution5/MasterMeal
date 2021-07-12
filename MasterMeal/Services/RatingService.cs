using MasterMeal.Models;
using MasterMeal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services
{
    public class RatingService : IRatingService
    {
        public Task<List<Rating>> GetRatingsByRecipieAsync(int recipieId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Rating>> GetRatingsByUserAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
