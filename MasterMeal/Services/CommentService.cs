using MasterMeal.Data;
using MasterMeal.Models;
using MasterMeal.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Comment>> GetRecipieCommentsAsync(int recipieId)
        {
            var comments = await _context.Comment.Where(c => c.RecipieId == recipieId).ToListAsync();
            return comments;
        }

        public async Task<List<Comment>> GetUserCommentsAsync(string userId)
        {
            var comments = await _context.Comment.Where(c => c.ChefId == userId).ToListAsync();
            return comments;
        }
    }
}
