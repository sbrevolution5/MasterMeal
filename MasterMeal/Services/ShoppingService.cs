using MasterMeal.Data;
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
        private readonly ApplicationDbContext _context;

        public ShoppingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<List<QIngredient>> CreateListOfQIngredientsForShopping(List<Meal> meals)
        {
            //First list is all qingredients from meal.recipies
            //None are combined yet, to preserve the shopping notes for each recipie
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
