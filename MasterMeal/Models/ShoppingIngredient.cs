using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Models
{
    public class ShoppingIngredient
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public int Quantity { get; set; }
        public List<string> Notes { get; set; }
    }
}
