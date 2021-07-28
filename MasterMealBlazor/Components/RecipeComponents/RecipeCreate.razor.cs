using MasterMealBlazor.Models;
using MasterMealBlazor.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MasterMealBlazor.Components.RecipeComponents
{
    public partial class RecipeCreate : ComponentBase
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
                if (ingredient.MeasurementType == MeasurementType.Volume)
                {
                    ingredient.MassMeasurementUnit = null;
                    ingredient.NumberOfUnits = _measurementService.EncodeVolumeMeasurement(ingredient.QuantityNumber, ingredient.Fraction, ingredient.VolumeMeasurementUnit.Value);
                    ingredient.Quantity = _measurementService.DecodeVolumeMeasurement(ingredient.NumberOfUnits);
                }
                if (ingredient.MeasurementType == MeasurementType.Volume)
                {
                    ingredient.VolumeMeasurementUnit = null;
                    ingredient.NumberOfUnits = _measurementService.EncodeMassMeasurement(ingredient.QuantityNumber, ingredient.Fraction, ingredient.MassMeasurementUnit.Value);
                    ingredient.Quantity = _measurementService.DecodeMassMeasurement(ingredient.NumberOfUnits);
                }
                if (ingredient.MeasurementType == MeasurementType.Volume)
                {
                    ingredient.VolumeMeasurementUnit = null;
                    ingredient.MassMeasurementUnit = null;
                    ingredient.NumberOfUnits = _measurementService.EncodeUnitMeasurement(ingredient.QuantityNumber, ingredient.Fraction);
                    ingredient.Quantity = _measurementService.DecodeUnitMeasurement(ingredient.NumberOfUnits);
                }
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
