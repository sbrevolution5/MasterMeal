using MasterMealBlazor.Models;
using MasterMealBlazor.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMealBlazor.Components.RecipeComponents
{
    public partial class RecipeCreate
    {
    private RecipeType[] Types;
        protected async override Task OnInitializedAsync()
        {
            using var context = ContextFactory.CreateDbContext();
            Types = await context.RecipeType.ToArrayAsync();



        }
        private List<Step> steps = new();
        private List<string> supplies = new();
        private List<QIngredient> ingredients = new();
        private string recipeName;
        private string recipeDescription;
        private int cookingTime;
        private int TypeId;
        private Recipe recipe = new();
        public async void SaveRecipe()
        {
            recipe.Name = recipeName;
            recipe.Description = recipeDescription;
            recipe.CookingTime = cookingTime;
            recipe.TypeId = TypeId;
            using var context = ContextFactory.CreateDbContext();
            context.Add(recipe);
            await context.SaveChangesAsync();
            foreach (var step in steps)
            {
                step.RecipeId = recipe.Id;
                context.Add(step);
            }
            foreach (var ingredient in ingredients)
            {
                ingredient.RecipeId = recipe.Id;
                context.Add(ingredient);
            }
            await context.SaveChangesAsync();

        }
        //private static void SaveStep(DbContext context, Step step)
        //{
        //    context.Add(step);
        //}
        public void AddStep()
        {
            steps.Add(new Models.Step());
        }
        public void AddSupply()
        {
            supplies.Add("");
        }
        public void AddIngredient()
        {
            ingredients.Add(new QIngredient());
        }
        public void RemoveIngredient(QIngredient i)
        {
            ingredients.Remove(i);
        }
        public void RemoveSupply(string i)
        {
            supplies.Remove(i);
        }
        public void RemoveStep(Step i)
        {
            steps.Remove(i);
        }
    }

}
