using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        /// <summary>
        /// This property is to determine what type of measurement to use.
        /// </summary>
        public bool UsesWeight { get; set; }
        public virtual IngredientType Type { get; set; }
    }
}
