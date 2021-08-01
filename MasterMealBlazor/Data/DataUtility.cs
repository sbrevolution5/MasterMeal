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

namespace MasterMealBlazor.Data
{
    public static class DataUtility
    {
        public static async Task ManageDataAsync(IHost host)
        {

            using var svcScope = host.Services.CreateScope();
            var svcProvider = svcScope.ServiceProvider;
            //Service: An instance of RoleManager
            var dbContextSvc = svcProvider.GetRequiredService<ApplicationDbContext>();
            //Service: An instance of RoleManager
            //var roleManagerSvc = svcProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //Service: An instance of the UserManager
            //var userManagerSvc = svcProvider.GetRequiredService<UserManager<Chef>>();
            //TsTEP 1: This is the programmatic equivalent to Update-Database
            await dbContextSvc.Database.MigrateAsync();
            await SeedDefaultImageAsync(dbContextSvc);
            await SeedRecipeTypesAsync(dbContextSvc);
        }

        private static async Task SeedDefaultImageAsync(ApplicationDbContext context)
        {
            var image = await context.Image.FirstOrDefaultAsync(i=>i.Id==1);
            if (image == null)
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
