using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string ChefId { get; set; }
        public virtual Chef Chef { get; set; }
        public int RecipieId { get; set; }
        public virtual Recipie Recipie { get; set; }
    }
}
