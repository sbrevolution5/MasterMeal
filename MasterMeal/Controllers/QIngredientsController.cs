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
    public class QIngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QIngredientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QIngredients
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.QIngredient.Include(q => q.Ingredient);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: QIngredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qIngredient = await _context.QIngredient
                .Include(q => q.Ingredient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qIngredient == null)
            {
                return NotFound();
            }

            return View(qIngredient);
        }

        // GET: QIngredients/Create
        public IActionResult Create()
        {
            ViewData["IngredientId"] = new SelectList(_context.Ingredient, "Id", "Id");
            return View();
        }

        // POST: QIngredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IngredientId,Notes,Quantity")] QIngredient qIngredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qIngredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IngredientId"] = new SelectList(_context.Ingredient, "Id", "Id", qIngredient.IngredientId);
            return View(qIngredient);
        }

        // GET: QIngredients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qIngredient = await _context.QIngredient.FindAsync(id);
            if (qIngredient == null)
            {
                return NotFound();
            }
            ViewData["IngredientId"] = new SelectList(_context.Ingredient, "Id", "Id", qIngredient.IngredientId);
            return View(qIngredient);
        }

        // POST: QIngredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IngredientId,Notes,Quantity")] QIngredient qIngredient)
        {
            if (id != qIngredient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qIngredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QIngredientExists(qIngredient.Id))
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
            ViewData["IngredientId"] = new SelectList(_context.Ingredient, "Id", "Id", qIngredient.IngredientId);
            return View(qIngredient);
        }

        // GET: QIngredients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qIngredient = await _context.QIngredient
                .Include(q => q.Ingredient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qIngredient == null)
            {
                return NotFound();
            }

            return View(qIngredient);
        }

        // POST: QIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qIngredient = await _context.QIngredient.FindAsync(id);
            _context.QIngredient.Remove(qIngredient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QIngredientExists(int id)
        {
            return _context.QIngredient.Any(e => e.Id == id);
        }
    }
}
