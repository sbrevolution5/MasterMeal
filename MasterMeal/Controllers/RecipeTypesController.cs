using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MasterMeal.Data;
using MasterMeal.Models;

namespace MasterMeal.Controllers
{
    public class RecipeTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipeTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RecipieTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecipieType.ToListAsync());
        }

        // GET: RecipieTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipieType = await _context.RecipieType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipieType == null)
            {
                return NotFound();
            }

            return View(recipieType);
        }

        // GET: RecipieTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecipieTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] RecipeType recipieType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipieType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipieType);
        }

        // GET: RecipieTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipieType = await _context.RecipieType.FindAsync(id);
            if (recipieType == null)
            {
                return NotFound();
            }
            return View(recipieType);
        }

        // POST: RecipieTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] RecipeType recipieType)
        {
            if (id != recipieType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipieType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipieTypeExists(recipieType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipieType);
        }

        // GET: RecipieTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipieType = await _context.RecipieType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipieType == null)
            {
                return NotFound();
            }

            return View(recipieType);
        }

        // POST: RecipieTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipieType = await _context.RecipieType.FindAsync(id);
            _context.RecipieType.Remove(recipieType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipieTypeExists(int id)
        {
            return _context.RecipieType.Any(e => e.Id == id);
        }
    }
}
