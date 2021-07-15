using MasterMeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services.Interfaces
{
    public interface IMealService
    {
        public Task<List<Meal>> GetUserMealsAsync(string userId);
        public Task<List<Meal>> GetUserMealsInDateRangeAsync(string userId,DateTime minDateInclusive, DateTime maxDateInclusive);
        public Task<List<Meal>> GetUserFutureMeals(string userId);

    }
}
