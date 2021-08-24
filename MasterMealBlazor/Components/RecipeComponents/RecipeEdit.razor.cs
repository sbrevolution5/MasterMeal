using MasterMealBlazor.Models;
using MasterMealBlazor.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using SixLabors.ImageSharp;
using Microsoft.AspNetCore.Http;

namespace MasterMealBlazor.Components.RecipeComponents
{
    public partial class RecipeEdit : ComponentBase
    {
        [Parameter]
        public string id { get; set; }
        private RecipeType[] Types;
        private IFormFile imageFile;
        private List<Step> steps = new();
        private List<Supply> supplies = new();
        private List<QIngredient> ingredients = new();
        private string recipeName;
        private string recipeDescription;
        private int cookingTime;
        private int TypeId;
        private Recipe recipe;
        protected async override Task OnInitializedAsync()
        {
            using var context = ContextFactory.CreateDbContext();
            Types = await context.RecipeType.ToArrayAsync();
            recipe = await context.Recipe.FirstOrDefaultAsync(i => i.Id == Convert.ToInt32(id));
        }
        public async void SaveRecipe()
        {
            recipe.Name = recipeName;
            recipe.Description = recipeDescription;
            recipe.CookingTime = cookingTime;
            recipe.TypeId = TypeId;
            recipe.Supplies = supplies;
            using var context = ContextFactory.CreateDbContext();
            int imageId = 1;
            if (imageFile is not null)
            {
                using var image = Image.Load(imageFile.OpenReadStream());
                var imageBytes = await _fileService.ConvertFileToByteArrayAsync(image, imageFile.ContentType);
                DBImage dBImage = new()
                {
                    ContentType = imageFile.ContentType,
                    ImageData = imageBytes
                };
                context.Add(dBImage);
                await context.SaveChangesAsync();
                imageId = dBImage.Id;
            }
            recipe.ImageId = imageId;
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
                else if (ingredient.MeasurementType == MeasurementType.Mass)
                {
                    ingredient.VolumeMeasurementUnit = null;
                    ingredient.NumberOfUnits = _measurementService.EncodeMassMeasurement(ingredient.QuantityNumber, ingredient.Fraction, ingredient.MassMeasurementUnit.Value);
                    ingredient.Quantity = _measurementService.DecodeMassMeasurement(ingredient.NumberOfUnits);
                }
                else if (ingredient.MeasurementType == MeasurementType.Count)
                {
                    ingredient.VolumeMeasurementUnit = null;
                    ingredient.MassMeasurementUnit = null;
                    ingredient.NumberOfUnits = _measurementService.EncodeUnitMeasurement(ingredient.QuantityNumber, ingredient.Fraction);
                    ingredient.Quantity = _measurementService.DecodeUnitMeasurement(ingredient.NumberOfUnits);
                }
                context.Add(ingredient);
            }
            await context.SaveChangesAsync();
            navigationManager.NavigateTo("/recipe/index");
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
            supplies.Add(new Supply());
        }
        public void AddIngredient()
        {
            ingredients.Add(new QIngredient());
        }
        public void RemoveIngredient(QIngredient i)
        {
            ingredients.Remove(i);
        }
        public void RemoveSupply(Supply i)
        {
            supplies.Remove(i);
        }
        public void RemoveStep(Step i)
        {
            steps.Remove(i);
        }
        public void DoNothing()
        {
            return;
        }
    }
} 