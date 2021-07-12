using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Models
{
    public class ShoppingList
    {
        public int Id { get; set; }
        public string ChefId { get; set; }
        public virtual Chef Chef { get; set; }
        public List<ShoppingIngredient> ShoppingIngredients { get; set; }
    }
}
