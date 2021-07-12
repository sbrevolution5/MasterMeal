﻿using MasterMeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services.Interfaces
{
    public interface ICommentService
    {
        public List<Comment> GetRecipieCommentsAsync(int recipieId);
        public List<Comment> GetUserCommentsAsync(string userId);
    }
}
