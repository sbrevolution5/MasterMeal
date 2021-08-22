using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMealBlazor.Models
{
    public class Supply
    {
        public Supply()
        {
            this.Recipes = new HashSet<Recipe>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
