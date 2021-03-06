using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MasterMeal.Models;

namespace MasterMeal.Data
{
    public class ApplicationDbContext : IdentityDbContext<Chef>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MasterMeal.Models.Comment> Comment { get; set; }
        public DbSet<MasterMeal.Models.Ingredient> Ingredient { get; set; }
        public DbSet<MasterMeal.Models.Meal> Meal { get; set; }
        public DbSet<MasterMeal.Models.QIngredient> QIngredient { get; set; }
        public DbSet<MasterMeal.Models.Rating> Rating { get; set; }
        public DbSet<MasterMeal.Models.Recipe> Recipe { get; set; }
        public DbSet<MasterMeal.Models.RecipeType> RecipeType { get; set; }
        public DbSet<MasterMeal.Models.Step> Step { get; set; }
        public DbSet<MasterMeal.Models.Supply> Supply { get; set; }
        public DbSet<MasterMeal.Models.IngredientType> IngredientType { get; set; }
    }
}
