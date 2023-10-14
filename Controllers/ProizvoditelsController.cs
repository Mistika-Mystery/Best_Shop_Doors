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
    public class ProizvoditelsController : Controller
    {
        private readonly Best_Shop_DoorsContext _context;

        public ProizvoditelsController(Best_Shop_DoorsContext context)
        {
            _context = context;
        }

        // GET: Proizvoditels
        public async Task<IActionResult> Index()
        {
              return _context.Proizvoditel != null ? 
                          View(await _context.Proizvoditel.ToListAsync()) :
                          Problem("Entity set 'Best_Shop_DoorsContext.Proizvoditel'  is null.");
        }

        // GET: Proizvoditels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proizvoditel == null)
            {
                return NotFound();
            }

            var proizvoditel = await _context.Proizvoditel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (proizvoditel == null)
            {
                return NotFound();
            }

            return View(proizvoditel);
        }

        // GET: Proizvoditels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proizvoditels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Proizvoditel proizvoditel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proizvoditel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proizvoditel);
        }

        // GET: Proizvoditels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proizvoditel == null)
            {
                return NotFound();
            }

            var proizvoditel = await _context.Proizvoditel.FindAsync(id);
            if (proizvoditel == null)
            {
                return NotFound();
            }
            return View(proizvoditel);
        }

        // POST: Proizvoditels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Proizvoditel proizvoditel)
        {
            if (id != proizvoditel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proizvoditel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProizvoditelExists(proizvoditel.ID))
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
            return View(proizvoditel);
        }

        // GET: Proizvoditels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proizvoditel == null)
            {
                return NotFound();
            }

            var proizvoditel = await _context.Proizvoditel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (proizvoditel == null)
            {
                return NotFound();
            }

            return View(proizvoditel);
        }

        // POST: Proizvoditels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Proizvoditel == null)
            {
                return Problem("Entity set 'Best_Shop_DoorsContext.Proizvoditel'  is null.");
            }
            var proizvoditel = await _context.Proizvoditel.FindAsync(id);
            if (proizvoditel != null)
            {
                _context.Proizvoditel.Remove(proizvoditel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProizvoditelExists(int id)
        {
          return (_context.Proizvoditel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
