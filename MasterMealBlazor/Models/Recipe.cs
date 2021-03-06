using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMealBlazor.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Supplies = new HashSet<Supply>();
        }
        public int Id { get; set; }
        public virtual ICollection<QIngredient> Ingredients { get; set; } = new HashSet<QIngredient>();
        public virtual ICollection<Step> Steps { get; set; } = new HashSet<Step>();
        public int Servings { get; set; }
        public string Name { get; set; }
        public int CookingTime { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; } = new HashSet<Rating>();
        public string AuthorId { get; set; }
        public virtual Chef Author { get; set; }
        public int TypeId { get; set; }
        public int ImageId { get; set; }
        public virtual RecipeType Type { get; set; }
        public virtual DBImage Image { get; set; }
        public string RecipeSource { get; set; } = "";
        public string RecipeSourceUrl { get; set; } = "";
        //Many to many, Not virtual!
        public ICollection<Supply> Supplies { get; set; } = new List<Supply>();
        [NotMapped]
        public float AvgRating
        {
            get
            {
                float avg=0f;
                if(Ratings?.Count == 0)
                {
                    return avg;
                }
                int total=0;
                foreach (var rating in Ratings)
                {
                    total += rating.Stars;
                }
                avg = total / Ratings.Count;
                return avg;
            }
        }
    }
}
