using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Best_Shop_Doors.Data;
using Best_Shop_Doors.Models;

namespace Best_Shop_Doors.Controllers
{
    public class ZakazsController : Controller
    {
        private readonly Best_Shop_DoorsContext _context;

        public ZakazsController(Best_Shop_DoorsContext context)
        {
            _context = context;
        }

        // GET: Zakazs
        public async Task<IActionResult> Index()
        {
              return _context.Zakaz != null ? 
                          View(await _context.Zakaz.ToListAsync()) :
                          Problem("Entity set 'Best_Shop_DoorsContext.Zakaz'  is null.");
        }

        // GET: Zakazs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zakaz == null)
            {
                return NotFound();
            }

            var zakaz = await _context.Zakaz
                .FirstOrDefaultAsync(m => m.ID == id);
            if (zakaz == null)
            {
                return NotFound();
            }

            return View(zakaz);
        }

        // GET: Zakazs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zakazs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AppUserID,Date")] Zakaz zakaz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zakaz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zakaz);
        }

        // GET: Zakazs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zakaz == null)
            {
                return NotFound();
            }

            var zakaz = await _context.Zakaz.FindAsync(id);
            if (zakaz == null)
            {
                return NotFound();
            }
            return View(zakaz);
        }

        // POST: Zakazs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AppUserID,Date")] Zakaz zakaz)
        {
            if (id != zakaz.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zakaz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZakazExists(zakaz.ID))
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
            return View(zakaz);
        }

        // GET: Zakazs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zakaz == null)
            {
                return NotFound();
            }

            var zakaz = await _context.Zakaz
                .FirstOrDefaultAsync(m => m.ID == id);
            if (zakaz == null)
            {
                return NotFound();
            }

            return View(zakaz);
        }

        // POST: Zakazs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zakaz == null)
            {
                return Problem("Entity set 'Best_Shop_DoorsContext.Zakaz'  is null.");
            }
            var zakaz = await _context.Zakaz.FindAsync(id);
            if (zakaz != null)
            {
                _context.Zakaz.Remove(zakaz);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZakazExists(int id)
        {
          return (_context.Zakaz?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
