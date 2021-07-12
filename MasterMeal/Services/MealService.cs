using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterMeal.Data;
using MasterMeal.Models;
using MasterMeal.Services.Interfaces;
namespace MasterMeal.Services
{
    public class MealService : IMealService
    {
        private readonly ApplicationDbContext _context;

        public MealService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Meal> GetUserMealsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public List<Meal> GetUserMealsInDateRangeAsync(string userId, DateTime minDateInclusive, DateTime maxDateInclusive)
        {
            throw new NotImplementedException();
        }
    }
}
