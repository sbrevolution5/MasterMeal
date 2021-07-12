using MasterMeal.Models;
using MasterMeal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services
{
    public class ShoppingService : IShoppingService
    {
        public List<List<QIngredient>> CreateListOfQIngredientsForShopping(List<Meal> meals)
        {
            throw new NotImplementedException();
        }

        public ShoppingIngredient CreateShoppingIngredientFromQIngredient(List<QIngredient> recipieIngredients)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingList> CreateShoppingListFromMealsAsync(List<Meal> meals)
        {
            throw new NotImplementedException();
        }
    }
}
