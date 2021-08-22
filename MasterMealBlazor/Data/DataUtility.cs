using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterMealBlazor.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.IO;
using MasterMealBlazor.Enums;

namespace MasterMealBlazor.Data
{
    public static class DataUtility
    {
        public static async Task ManageDataAsync(IHost host)
        {

            using var svcScope = host.Services.CreateScope();
            var svcProvider = svcScope.ServiceProvider;
            //Service: An instance of DBContext
            var dbContextSvc = svcProvider.GetRequiredService<ApplicationDbContext>();
            //Service: An instance of RoleManager
            //var roleManagerSvc = svcProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //Service: An instance of the UserManager
            //var userManagerSvc = svcProvider.GetRequiredService<UserManager<Chef>>();
            //TsTEP 1: This is the programmatic equivalent to Update-Database
            await dbContextSvc.Database.MigrateAsync();
            await SeedDefaultImagesAsync(dbContextSvc);
            await SeedRecipeTypesAsync(dbContextSvc);
            await SeedIngredientTypesAsync(dbContextSvc);
        }

        private static async Task SeedDefaultImagesAsync(ApplicationDbContext context)
        {
            var mealImage = await context.DBImage.FirstOrDefaultAsync(i=>i.Id==1);
            if (mealImage == null)
            {
                var file = $"{Directory.GetCurrentDirectory()}/wwwroot/DefaultRecipe.jpg";
                var fileData = await File.ReadAllBytesAsync(file);
                var newImage = new DBImage(){
                    ImageData = fileData,
                    ContentType = "jpg",
                    Id = 1
                };
                context.Add(newImage);
                await context.SaveChangesAsync();
            }
            var userImage = await context.DBImage.FirstOrDefaultAsync(i=>i.Id==2);
            if (userImage == null)
            {
                var file = $"{Directory.GetCurrentDirectory()}/wwwroot/DefaultUser.png";
                var fileData = await File.ReadAllBytesAsync(file);
                var newImage = new DBImage(){
                    ImageData = fileData,
                    ContentType = "png",
                    Id = 2
                };
                context.Add(newImage);
                await context.SaveChangesAsync();
            }

        }
        private static async Task SeedIngredientTypesAsync(ApplicationDbContext context)
        {
            if ((await context.IngredientType.ToListAsync()).Count() < 1)
            {
                var types = new List<IngredientType>();
                types.Add(NewType("Dairy"));
                types.Add(NewType("Meat"));
                types.Add(NewType("Cold Products"));
                types.Add(NewType("Frozen Products"));
                types.Add(NewType("Produce"));
                types.Add(NewType("Bread"));
                types.Add(NewType("Spice"));
                types.Add(NewType("Breadcrumb"));
                types.Add(NewType("Oil"));
                types.Add(NewType("Baking Needs"));
                types.Add(NewType("Deli Meat"));
                types.Add(NewType("Condiments and Sauces"));
                types.Add(NewType("Cheese"));
                types.Add(NewType("Canned Good"));
                types.Add(NewType("Soup"));
                types.Add(NewType("Pasta"));
                await context.SaveChangesAsync();
            }

        }
        private static IngredientType NewType(string name)
        {
            return new IngredientType() { Name = name };
        }
        private static async Task SeedIngredientsAsync(ApplicationDbContext context)
        {
            if ((await context.Ingredient.ToListAsync()).Count() < 1)
            {
                var ingredients = new List<Ingredient>();
                var ingTypes = await context.IngredientType.ToListAsync();
                //Ancho BBQ Sloppy Joes Ingredients
                ingredients.Add(MakeIngredient("BBQ Sauce", "Condiments and Sauces", MeasurementType.Volume, context,ingTypes));
                ingredients.Add(MakeIngredient("Ketchup", "Condiments and Sauces", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Cornstarch", "Baking Needs", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Yellow Onion", "Produce", MeasurementType.Count, context, ingTypes));
                ingredients.Add(MakeIngredient("Ancho Chili Powder", "Spice", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Gold Potatoes", "Produce", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Dill Pickle", "Produce", MeasurementType.Count, context, ingTypes));
                ingredients.Add(MakeIngredient("Potato Buns", "Bread", MeasurementType.Count, context, ingTypes));
                ingredients.Add(MakeIngredient("Beef Stock Concentrate", "Soup", MeasurementType.Count, context, ingTypes));
                ingredients.Add(MakeIngredient("Ground Beef", "Meat", MeasurementType.Mass, context, ingTypes));
                ingredients.Add(MakeIngredient("Olive Oil", "Oil", MeasurementType.Volume, context, ingTypes));
                //Buffalo Spiced Crispy Chicken
                ingredients.Add(MakeIngredient("Sour Cream", "Cold Products", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Panko Breadcrumbs", "Breadcrumb", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Honey", "Condiments and Sauces", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Green Beans", "Produce", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Scallions", "Produce", MeasurementType.Count, context, ingTypes));
                ingredients.Add(MakeIngredient("Frank's Seasoning Blend", "Spices", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Montrey Jack (Shredded)", "Cheese", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Chicken Breast", "Meat", MeasurementType.Mass, context, ingTypes));
                //Beef and cheese tostadas
                ingredients.Add(MakeIngredient("Roma Tomato", "Produce", MeasurementType.Count, context, ingTypes));
                ingredients.Add(MakeIngredient("Green Bell Pepper", "Produce", MeasurementType.Count, context, ingTypes));
                ingredients.Add(MakeIngredient("Flour Tortillas", "Bread", MeasurementType.Count, context, ingTypes));
                ingredients.Add(MakeIngredient("Mexican Cheese (Shredded)", "Cheese", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Chili Powder", "Spices", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Olive Oil", "Oil", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Olive Oil", "Oil", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Olive Oil", "Oil", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Olive Oil", "Oil", MeasurementType.Volume, context, ingTypes));
            }
        }
        private static Ingredient MakeIngredient(string name, string type, MeasurementType measurement, ApplicationDbContext context, List<IngredientType> types)
        {
            var typeId = (types.Where(t => t.Name == type).FirstOrDefault()).Id;
            return new Ingredient() { Name = name, TypeId = typeId, MeasurementType = measurement };
        }
        private static async Task SeedRecipeTypesAsync(ApplicationDbContext context)
        {
            if ((await context.RecipeType.ToListAsync()).Count()<1)
            {
                var types = new List<RecipeType>();
                types.Add(new()
                {
                    Name = "American"
                });
                types.Add(new()
                {
                    Name = "Mexican"
                });
                types.Add(new()
                {
                    Name = "Seafood"
                });
                types.Add(new()
                {
                    Name = "Italian"
                });
                types.Add(new()
                {
                    Name = "Breakfast"
                });
                types.Add(new()
                {
                    Name = "Asian"
                });
                context.AddRange(types);
                await context.SaveChangesAsync();
            }
        }
    }
}
