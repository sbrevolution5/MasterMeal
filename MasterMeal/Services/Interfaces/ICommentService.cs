using MasterMeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services.Interfaces
{
    public interface ICommentService
    {
        public Task<List<Comment>> GetRecipeCommentsAsync(int RecipeId);
        public Task<List<Comment>> GetUserCommentsAsync(string userId);
    }
}
