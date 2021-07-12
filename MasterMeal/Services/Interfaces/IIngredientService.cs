﻿using MasterMeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services.Interfaces
{
    public interface IIngredientService
    {
        public List<Ingredient> GetRecipieIngredientsAsync(int recipieId);
        public List<Ingredient> GetShoppingListIngredientsAsync(int shoppingListId);
    }
}
