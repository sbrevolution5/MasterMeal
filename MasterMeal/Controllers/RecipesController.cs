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
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recipies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Recipe.Include(r => r.Type);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Recipies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipie = await _context.Recipe
                .Include(r => r.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipie == null)
            {
                return NotFound();
            }

            return View(recipie);
        }

        // GET: Recipies/Create
        public IActionResult Create()
        {
            ViewData["TypeId"] = new SelectList(_context.Set<RecipeType>(), "Id", "Id");
            return View();
        }

        // POST: Recipies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CookingTime,Description,AuthorId,TypeId")] Recipe recipie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeId"] = new SelectList(_context.Set<RecipeType>(), "Id", "Id", recipie.TypeId);
            return View(recipie);
        }

        // GET: Recipies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipie = await _context.Recipe.FindAsync(id);
            if (recipie == null)
            {
                return NotFound();
            }
            ViewData["TypeId"] = new SelectList(_context.Set<RecipeType>(), "Id", "Id", recipie.TypeId);
            return View(recipie);
        }

        // POST: Recipies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CookingTime,Description,AuthorId,TypeId")] Recipe recipie)
        {
            if (id != recipie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipieExists(recipie.Id))
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
            ViewData["TypeId"] = new SelectList(_context.Set<RecipeType>(), "Id", "Id", recipie.TypeId);
            return View(recipie);
        }

        // GET: Recipies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipie = await _context.Recipe
                .Include(r => r.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipie == null)
            {
                return NotFound();
            }

            return View(recipie);
        }

        // POST: Recipies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipie = await _context.Recipe.FindAsync(id);
            _context.Recipe.Remove(recipie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipieExists(int id)
        {
            return _context.Recipe.Any(e => e.Id == id);
        }
    }
}
