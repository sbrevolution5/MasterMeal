using MasterMeal.Data;
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
        private readonly ApplicationDbContext _context;

        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

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
