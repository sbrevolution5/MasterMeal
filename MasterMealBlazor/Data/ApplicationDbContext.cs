using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterMealBlazor.Models;
namespace MasterMealBlazor.Data
{
    public class ApplicationDbContext: IdentityDbContext<Chef>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<QIngredient> QIngredient { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<RecipeType> RecipeType { get; set; }
        public DbSet<Step> Step { get; set; }
        public DbSet<Supply> Supply { get; set; }
        public DbSet<IngredientType> IngredientType { get; set; }
        public DbSet<DBImage> Image { get; set; }
    }
}
