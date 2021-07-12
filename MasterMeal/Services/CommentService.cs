using MasterMeal.Models;
using MasterMeal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services
{
    public class CommentService : ICommentService
    {
        public List<Comment> GetRecipieCommentsAsync(int recipieId)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetUserCommentsAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
