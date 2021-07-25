﻿using MasterMealBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMealBlazor.Services.Interfaces
{
    public interface IMealService
    {
        public Task<List<Meal>> GetUserMealsAsync(string chefId);
        public Task<List<Meal>> GetUserMealsInDateRangeAsync(string chefId,DateTime minDateInclusive, DateTime maxDateInclusive);
        public Task<List<Meal>> GetUserFutureMealsAsync(string chefId);

    }
}
