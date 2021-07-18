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

        // GET: RecipeTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RecipeType.ToListAsync());
        }

        // GET: RecipeTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var RecipeType = await _context.RecipeType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (RecipeType == null)
            {
                return NotFound();
            }

            return View(RecipeType);
        }

        // GET: RecipeTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecipeTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] RecipeType RecipeType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(RecipeType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(RecipeType);
        }

        // GET: RecipeTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var RecipeType = await _context.RecipeType.FindAsync(id);
            if (RecipeType == null)
            {
                return NotFound();
            }
            return View(RecipeType);
        }

        // POST: RecipeTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] RecipeType RecipeType)
        {
            if (id != RecipeType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(RecipeType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeTypeExists(RecipeType.Id))
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
            return View(RecipeType);
        }

        // GET: RecipeTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var RecipeType = await _context.RecipeType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (RecipeType == null)
            {
                return NotFound();
            }

            return View(RecipeType);
        }

        // POST: RecipeTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var RecipeType = await _context.RecipeType.FindAsync(id);
            _context.RecipeType.Remove(RecipeType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeTypeExists(int id)
        {
            return _context.RecipeType.Any(e => e.Id == id);
        }
    }
}
