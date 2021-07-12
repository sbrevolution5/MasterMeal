using MasterMeal.Models;
using MasterMeal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMeal.Services
{
    public class SupplyService : ISupplyService
    {
        public Task<List<Supply>> GetSuppliesForMultipleRecipiesAsync(List<Recipie> recipies)
        {
            throw new NotImplementedException();
        }

        public Task<List<Supply>> GetSuppliesForRecipieAsync(int recipieId)
        {
            throw new NotImplementedException();
        }

        public Task<Supply> GetSupplyByIdAsync(int supplyId)
        {
            throw new NotImplementedException();
        }
    }
}
