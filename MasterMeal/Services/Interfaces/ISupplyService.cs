using MasterMeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services.Interfaces
{
    public interface ISupplyService
    {
        public Task<Supply> GetSupplyByIdAsync(int supplyId);
    }
}
