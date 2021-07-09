using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Models
{
    public class Recipie
    {
        public int Id { get; set; }
        public virtual ICollection<QIngredient> Ingredients { get; set; }
        public virtual ICollection<Supply> Supplies { get; set; }
        public ICollection<Step> Steps { get; set; }
        public string Name { get; set; }
        public TimeSpan CookingTime { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public string AuthorId { get; set; }
        public int TypeId { get; set; }
        public virtual RecipieType Type { get; set; }
    }
}
