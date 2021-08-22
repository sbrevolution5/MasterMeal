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
using MasterMealBlazor.Services;

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
            await SeedIngredientsAsync(dbContextSvc);
            await SeedSuppliesAsync(dbContextSvc);
            await SeedRecipesAsync(dbContextSvc);
        }

        private static async Task SeedDefaultImagesAsync(ApplicationDbContext context)
        {
            var mealImage = await context.DBImage.FirstOrDefaultAsync(i => i.Id == 1);
            if (mealImage == null)
            {
                var file = $"{Directory.GetCurrentDirectory()}/wwwroot/DefaultRecipe.jpg";
                var fileData = await File.ReadAllBytesAsync(file);
                var newImage = new DBImage()
                {
                    ImageData = fileData,
                    ContentType = "jpg",
                    Id = 1
                };
                context.Add(newImage);
                await context.SaveChangesAsync();
            }
            var userImage = await context.DBImage.FirstOrDefaultAsync(i => i.Id == 2);
            if (userImage == null)
            {
                var file = $"{Directory.GetCurrentDirectory()}/wwwroot/DefaultUser.png";
                var fileData = await File.ReadAllBytesAsync(file);
                var newImage = new DBImage()
                {
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
                ingredients.Add(MakeIngredient("BBQ Sauce", "Condiments and Sauces", MeasurementType.Volume, context, ingTypes));
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
                ingredients.Add(MakeIngredient("Southwest Spice Blend", "Spices", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Lime", "Produce", MeasurementType.Count, context, ingTypes));
                ingredients.Add(MakeIngredient("Hot Sauce", "Condiments And Sauces", MeasurementType.Volume, context, ingTypes));
                ingredients.Add(MakeIngredient("Cilantro", "Produce", MeasurementType.Volume, context, ingTypes));
                await context.SaveChangesAsync();
            }
        }
        private static Ingredient MakeIngredient(string name, string type, MeasurementType measurement, ApplicationDbContext context, List<IngredientType> types)
        {
            var typeId = types.Where(t => t.Name == type).FirstOrDefault().Id;
            return new Ingredient() { Name = name, TypeId = typeId, MeasurementType = measurement };
        }
        private static async Task SeedSuppliesAsync(ApplicationDbContext context)
        {
            if ((await context.Supply.ToListAsync()).Count < 1)
            {
                var supplies = new List<Supply>();
                supplies.Add(NewSupply("Large Pan"));
                supplies.Add(NewSupply("Baking Sheet"));
                supplies.Add(NewSupply("Small Bowl"));
                supplies.Add(NewSupply("Medium Bowl"));
                supplies.Add(NewSupply("Olive Oil"));
                supplies.Add(NewSupply("Salt And Pepper"));
                await context.SaveChangesAsync();
            }
        }

        private static Supply NewSupply(string v)
        {
            var sup = new Supply()
            {
                Name = v
            };
            return sup;
        }

        private static async Task SeedRecipesAsync(ApplicationDbContext context)
        {
            if ((await context.Recipe.ToListAsync()).Count() < 1)
            {
                var types = await context.RecipeType.ToListAsync();
                var ing = await context.Ingredient.ToListAsync();
                var recipes = new List<Recipe>();
                var beefTostada = new Recipe()
                {
                    Name = "Beef & Cheese Tostadas",
                    Description = "With Green Bell Pepper, Tomato Salsa, & Hot Sauce Crema",
                    RecipeSource = "HelloFresh",
                    Servings = 2,
                    CookingTime = 30,
                    TypeId = types.Where(t => t.Name == "Mexican").FirstOrDefault().Id
                };
                var beefIng = new List<QIngredient>();
                beefIng.Add(NewQIngredient("Roma Tomato", 1,  ing,beefTostada.Id));
                beefIng.Add(NewQIngredient("Yellow Onion", 1, ing,beefTostada.Id));
                beefIng.Add(NewQIngredient("Green Bell Pepper", 1, ing,beefTostada.Id));
                beefIng.Add(NewQIngredient("Lime", 1, ing,beefTostada.Id));
                beefIng.Add(NewQIngredient("Beef Stock Concentrate", 1, ing,beefTostada.Id));
                beefIng.Add(NewQIngredient("Flour Tortillas", 6, ing,beefTostada.Id));
                beefIng.Add(NewQIngredient("Ground Beef", 10, Fraction.NoFraction, MassMeasurementUnit.ounce, ing, beefTostada.Id));
                beefIng.Add(NewQIngredient("Sour Cream", 4, Fraction.NoFraction, VolumeMeasurementUnit.Tablespoon, ing, beefTostada.Id));
                beefIng.Add(NewQIngredient("Mexican Cheese (Shredded)", 0, Fraction.Half, VolumeMeasurementUnit.Cup, ing, beefTostada.Id));
                beefIng.Add(NewQIngredient("Cilantro", 0, Fraction.Half, VolumeMeasurementUnit.Ounce, ing, beefTostada.Id));
                beefIng.Add(NewQIngredient("Hot Sauce", 1, Fraction.NoFraction, VolumeMeasurementUnit.Teaspoon, ing, beefTostada.Id));
                beefIng.Add(NewQIngredient("Chili Powder", 1, Fraction.NoFraction, VolumeMeasurementUnit.Teaspoon, ing, beefTostada.Id));
                beefIng.Add(NewQIngredient("Southwest Spice Blend", 1, Fraction.NoFraction, VolumeMeasurementUnit.Tablespoon, ing, beefTostada.Id));
                await context.SaveChangesAsync();
                var sup = await context.Supply.ToListAsync();
                var beefSupplies = new List<Supply>();
                beefSupplies.Add(AddSupply(beefSupplies, "Large Pan",sup));
                beefSupplies.Add(AddSupply(beefSupplies, "Baking Sheet",sup));
                beefSupplies.Add(AddSupply(beefSupplies, "Small Bowl",sup));
                beefSupplies.Add(AddSupply(beefSupplies, "Medium Bowl",sup));
                beefSupplies.Add(AddSupply(beefSupplies, "Olive Oil",sup));
                beefSupplies.Add(AddSupply(beefSupplies, "Salt And Pepper",sup));

                var beefSteps = new List<Step>();
                beefSteps.Add(AddStep("Preheat Oven to 450F.", beefTostada.Id));
                beefSteps.Add(AddStep("Dice tomato. Roughly chop cilantro. Halve and peel onion; thinly slice one half. Finely chop remaining onion until you have 2 TBS. Quarter lime. Halve, core, and thinly slice bell pepper into strips.", beefTostada.Id));
                beefSteps.Add(AddStep("In a medium bowl, combine tomato, cilantro, chopped onion, juice from half the lime, and a pinch of salt and pepper.", beefTostada.Id));
                beefSteps.Add(AddStep("In a small bowl, combine sour cream with as much hot sauce as you like.Stir in water 1 tsp.at a time until mixture reaches a drizzling consistency.Season with salt.", beefTostada.Id));
                beefSteps.Add(AddStep("Heat a drizzle of olive oil in a large pan over medium - high heat.Add beef, Southwest Spice, chili powder, and a few big pinches of salt.Cook, breaking up meat into pieces, until browned, 4 - 5 minutes.", beefTostada.Id));
                beefSteps.Add(AddStep("Once beef is browned, add bell pepper, sliced onion, and a pinch of salt to pan.Cook, stirring, until veggies are tender and beef is cooked through, 5 - 7 minutes. ", beefTostada.Id));
                beefSteps.Add(AddStep("Add stock concentrate and ¼ cup water.Simmer until thickened, 1 - 2 minutes.Season with salt; remove pan from heat and set aside.", beefTostada.Id));
                beefSteps.Add(AddStep("Drizzle tortillas with 1 TBS olive oil; brush or rub to coat all over.Arrange on a baking sheet.Gently prick each tortilla in a few places with a fork.", beefTostada.Id));
                beefSteps.Add(AddStep("Bake on top rack, flipping halfway through, until lightly golden, 4 - 5 minutes per side.", beefTostada.Id));
                beefSteps.Add(AddStep("Serve and top with pico de gallo and lime crema", beefTostada.Id));
            }
        }

        private static Step AddStep(string v, int id)
        {
            var step = new Step()
            {
                Text = v,
                RecipeId = id
            };
            return step;
        }

        private static Supply AddSupply(List<Supply> beefSupplies, string v, List<Supply> sup)
        {
            Supply supply = sup.Where(s => s.Name == v).FirstOrDefault();
            return supply;
        }

        private static QIngredient NewQIngredient(string name, int count, List<Ingredient> ingredients, int rId)
        {
            var _measurementService = new MeasurementService();
            var ingId = ingredients.Where(i => i.Name == name).FirstOrDefault().Id;
            var qing = new QIngredient()
            {
                IngredientId = ingId,
                MeasurementType = MeasurementType.Count,
                QuantityNumber = count,
            };
            qing.RecipeId = rId;
            return qing;
        }
        private static QIngredient NewQIngredient(string name, int count, Fraction frac, VolumeMeasurementUnit unit, List<Ingredient> ingredients, int rId)
        {
            var _measurementService = new MeasurementService();
            var ingId = ingredients.Where(i => i.Name == name).FirstOrDefault().Id;
            var qing = new QIngredient()
            {
                IngredientId = ingId,
                Fraction = frac,
                MeasurementType = MeasurementType.Volume,
                QuantityNumber = count,
                NumberOfUnits = _measurementService.EncodeVolumeMeasurement(count, frac, unit)
            };
            qing.Quantity = _measurementService.DecodeVolumeMeasurement(qing.NumberOfUnits);
            qing.RecipeId = rId;
            return qing;
        }
        private static QIngredient NewQIngredient(string name, int count, Fraction frac, MassMeasurementUnit mass, List<Ingredient> ingredients, int rId)
        {
            var _measurementService = new MeasurementService();
            var ingId = ingredients.Where(i => i.Name == name).FirstOrDefault().Id;
            var qing = new QIngredient()
            {
                IngredientId = ingId,
                Fraction = frac,
                MeasurementType = MeasurementType.Mass,
                QuantityNumber = count,
                NumberOfUnits = _measurementService.EncodeMassMeasurement(count, frac, mass)
            };
            qing.Quantity = _measurementService.DecodeMassMeasurement(qing.NumberOfUnits);
            qing.RecipeId = rId;
            return qing;
        }
        private static async Task SeedRecipeTypesAsync(ApplicationDbContext context)
        {
            if ((await context.RecipeType.ToListAsync()).Count() < 1)
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
