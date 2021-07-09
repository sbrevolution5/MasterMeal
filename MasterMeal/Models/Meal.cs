﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public int Serves { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int ImageId { get; set; }
        public virtual ImageFile Image { get; set; }
        public int RecipieId { get; set; }
        public virtual Recipie Recipie { get; set; }
    }
}
