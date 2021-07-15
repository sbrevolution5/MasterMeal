using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public virtual ICollection<QIngredient> Ingredients { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
        public ICollection<Step> Steps { get; set; }
        public string Name { get; set; }
        public int CookingTime { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public string AuthorId { get; set; }
        public virtual Chef Author { get; set; }
        public int TypeId { get; set; }
        public virtual RecipeType Type { get; set; }
        [NotMapped]
        public float AvgRating
        {
            get
            {
                float avg=0f;
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
