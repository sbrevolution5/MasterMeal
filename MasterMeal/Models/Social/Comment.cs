using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentBody { get; set; }
        public string UserId { get; set; }
        public DateTime Created { get; set; }
    }
}
