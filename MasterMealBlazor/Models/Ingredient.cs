using MasterMealBlazor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMealBlazor.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public virtual IngredientType Type { get; set; }
        public MeasurementType MeasurementType { get; set; }
    }
}
