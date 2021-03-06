using MasterMealBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMealBlazor.Services.Interfaces
{
    interface IShoppingService
    {
        public Task<ShoppingList> CreateShoppingListFromMealsAsync(List<Meal> meals);
        public List<QIngredient> CreateListOfQIngredientsForShopping(List<Meal> meals);
        public List<ShoppingIngredient> CreateShoppingIngredientFromQIngredients(List<QIngredient> allIngredients);
        public ShoppingIngredient CreateOneShoppingIngredientFromMultipleQIngredients(List<QIngredient> listOfOneIngredient);

    }
}
