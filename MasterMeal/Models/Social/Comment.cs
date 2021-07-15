using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int RecipieId { get; set; }
        public virtual Recipe Recipie { get; set; }
        public string CommentBody { get; set; }
        public string ChefId { get; set; }
        public virtual Chef Chef { get; set; }
        public DateTime Created { get; set; }
    }
}
