using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Models.ViewModel
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        public ICollection<QIngredient> Ingredients { get; set; }
        public ICollection<Supply> Supplies { get; set; }
        public ICollection<Step> Steps { get; set; }
        public string Name { get; set; }
        public int CookingTime { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
        public virtual Chef Author { get; set; }
        public int TypeId { get; set; }
        public virtual RecipeType Type { get; set; }
        
    }
}
