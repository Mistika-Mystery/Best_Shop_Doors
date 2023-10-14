using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Best_Shop_Doors.Data;
using Best_Shop_Doors.Models;
using Best_Shop_Doors.Constant;
using Microsoft.AspNetCore.Authorization;

namespace Best_Shop_Doors.Controllers
{
    public class TipsController : Controller
    {
        private readonly Best_Shop_DoorsContext _context;

        public TipsController(Best_Shop_DoorsContext context)
        {
            _context = context;
        }

        // GET: Tips
        public async Task<IActionResult> Index()
        {
              return _context.Tip != null ? 
                          View(await _context.Tip.ToListAsync()) :
                          Problem("Entity set 'Best_Shop_DoorsContext.Tip'  is null.");
        }

        // GET: Tips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tip == null)
            {
                return NotFound();
            }

            var tip = await _context.Tip
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tip == null)
            {
                return NotFound();
            }

            return View(tip);
        }

        // GET: Tips/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Tip tip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tip);
        }

        // GET: Tips/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tip == null)
            {
                return NotFound();
            }

            var tip = await _context.Tip.FindAsync(id);
            if (tip == null)
            {
                return NotFound();
            }
            return View(tip);
        }

        // POST: Tips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Tip tip)
        {
            if (id != tip.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipExists(tip.ID))
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
            return View(tip);
        }

        // GET: Tips/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tip == null)
            {
                return NotFound();
            }

            var tip = await _context.Tip
                .FirstOrDefaultAsync(m => m.ID == id);
            if (tip == null)
            {
                return NotFound();
            }

            return View(tip);
        }

        // POST: Tips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tip == null)
            {
                return Problem("Entity set 'Best_Shop_DoorsContext.Tip'  is null.");
            }
            var tip = await _context.Tip.FindAsync(id);
            if (tip != null)
            {
                _context.Tip.Remove(tip);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipExists(int id)
        {
          return (_context.Tip?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
