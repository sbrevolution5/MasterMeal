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

        public List<QIngredient> CreateListOfQIngredientsForShopping(List<Meal> meals)
        {
            //First list is all qingredients from meal.Recipes
            List<QIngredient> qIngredients = new();
            foreach (var meal in meals)
            {
                foreach (var qIngredient in meal.Recipe.Ingredients)
                {
                    qIngredients.Add(qIngredient);
                }
            }
            //None are combined yet, to preserve the shopping notes for each Recipe
            //ordered to make it easier to parse in next step
            return qIngredients.OrderByDescending(q=>q.IngredientId).ToList();
        }

        public ShoppingIngredient CreateOneShoppingIngredientFromMultipleQIngredients(List<QIngredient> listOfOneIngredient)
        {
            List<string> notes = new();
            string totalQuantity = ""; //TODO this needs to be changed to correct measurement
            foreach (var qingredient in listOfOneIngredient)
            {

                //If string has Notes (it always has shopping notes due to quantity)
                if (!string.IsNullOrWhiteSpace(qingredient.Notes) )
                {
                    notes.Add(qingredient.ShoppingNotes);
                }
            }
            ShoppingIngredient result = new()
            {
                Measurement = totalQuantity,
                IngredientId = listOfOneIngredient.First().IngredientId,
                Notes = notes
            };

            return result;
        }

        public List<ShoppingIngredient> CreateShoppingIngredientFromQIngredients(List<QIngredient> allIngredients)
        {
            //All ingredients that are the same Id need to be combined, and removed from the list until list is empty.  
            //pass to subfunction to combine
            throw new NotImplementedException();
        }

        public Task<ShoppingList> CreateShoppingListFromMealsAsync(List<Meal> meals)
        {
            throw new NotImplementedException();
        }
    }
}
