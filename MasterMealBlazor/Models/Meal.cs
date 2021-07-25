using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMealBlazor.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public int Serves { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string ChefId { get; set; }
        public virtual Chef Chef { get; set; }
        public int ImageId { get; set; }
        public virtual ImageFile Image { get; set; }
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
