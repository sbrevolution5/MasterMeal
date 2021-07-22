using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MasterMeal.Data;
using MasterMeal.Models;
using Microsoft.AspNetCore.Identity;

namespace MasterMeal.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Chef> _userManager;

        public RecipesController(ApplicationDbContext context, UserManager<Chef> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Recipe.Include(r => r.Type);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Recipe = await _context.Recipe
                .Include(r => r.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Recipe == null)
            {
                return NotFound();
            }

            return View(Recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            ViewData["TypeId"] = new SelectList(_context.Set<RecipeType>(), "Id", "Name");
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CookingTime,Description,TypeId")] Recipe Recipe)
        {

            if (ModelState.IsValid)
            {
                Recipe.AuthorId = _userManager.GetUserId(User);
                _context.Add(Recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeId"] = new SelectList(_context.Set<RecipeType>(), "Id", "Id", Recipe.TypeId);
            return View(Recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Recipe = await _context.Recipe.FindAsync(id);
            if (Recipe == null)
            {
                return NotFound();
            }
            ViewData["TypeId"] = new SelectList(_context.Set<RecipeType>(), "Id", "Id", Recipe.TypeId);
            return View(Recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CookingTime,Description,AuthorId,TypeId")] Recipe Recipe)
        {
            if (id != Recipe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(Recipe.Id))
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
            ViewData["TypeId"] = new SelectList(_context.Set<RecipeType>(), "Id", "Id", Recipe.TypeId);
            return View(Recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Recipe = await _context.Recipe
                .Include(r => r.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Recipe == null)
            {
                return NotFound();
            }

            return View(Recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Recipe = await _context.Recipe.FindAsync(id);
            _context.Recipe.Remove(Recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.Id == id);
        }
    }
}
