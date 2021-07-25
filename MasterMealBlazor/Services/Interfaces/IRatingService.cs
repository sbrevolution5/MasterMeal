using MasterMealBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMealBlazor.Services.Interfaces
{
    public interface IRatingService
    {
        public Task<List<Rating>> GetRatingsByUserAsync(string userId);
    }
}
