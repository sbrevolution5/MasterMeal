using MasterMeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services.Interfaces
{
    public interface IMealService
    {
        public List<Meal> GetUserMealsAsync(string userId);
        public List<Meal> GetUserMealsInDateRangeAsync(string userId,DateTime minDateInclusive, DateTime maxDateInclusive);
    }
}
