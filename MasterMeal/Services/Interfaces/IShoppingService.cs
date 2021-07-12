using MasterMeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services.Interfaces
{
    interface IShoppingService
    {
        public Task<ShoppingList> CreateShoppingListFromMealsAsync(List<Meal> meals);
        public List<List<QIngredient>> CreateListOfQIngredientsForShopping(List<Meal> meals);
        public ShoppingIngredient CreateShoppingIngredientFromQIngredient(List<QIngredient> recipieIngredients);

    }
}
