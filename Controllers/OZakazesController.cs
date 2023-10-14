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
    public class OZakazesController : Controller
    {
        private readonly Best_Shop_DoorsContext _context;

        public OZakazesController(Best_Shop_DoorsContext context)
        {
            _context = context;
        }

        // GET: OZakazes
        public async Task<IActionResult> Index()
        {
            var best_Shop_DoorsContext = _context.OZakaze.Include(o => o.Door).Include(o => o.Zakaz);
            return View(await best_Shop_DoorsContext.ToListAsync());
        }

        // GET: OZakazes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OZakaze == null)
            {
                return NotFound();
            }

            var oZakaze = await _context.OZakaze
                .Include(o => o.Door)
                .Include(o => o.Zakaz)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (oZakaze == null)
            {
                return NotFound();
            }

            return View(oZakaze);
        }

        // GET: OZakazes/Create
        public IActionResult Create()
        {
            ViewData["DoorID"] = new SelectList(_context.Door, "ID", "ID");
            ViewData["ZakazID"] = new SelectList(_context.Set<Zakaz>(), "ID", "ID");
            return View();
        }

        // POST: OZakazes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ZakazID,DoorID,Kolich")] OZakaze oZakaze)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oZakaze);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoorID"] = new SelectList(_context.Door, "ID", "ID", oZakaze.DoorID);
            ViewData["ZakazID"] = new SelectList(_context.Set<Zakaz>(), "ID", "ID", oZakaze.ZakazID);
            return View(oZakaze);
        }

        // GET: OZakazes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OZakaze == null)
            {
                return NotFound();
            }

            var oZakaze = await _context.OZakaze.FindAsync(id);
            if (oZakaze == null)
            {
                return NotFound();
            }
            ViewData["DoorID"] = new SelectList(_context.Door, "ID", "ID", oZakaze.DoorID);
            ViewData["ZakazID"] = new SelectList(_context.Set<Zakaz>(), "ID", "ID", oZakaze.ZakazID);
            return View(oZakaze);
        }

        // POST: OZakazes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ZakazID,DoorID,Kolich")] OZakaze oZakaze)
        {
            if (id != oZakaze.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oZakaze);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OZakazeExists(oZakaze.ID))
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
            ViewData["DoorID"] = new SelectList(_context.Door, "ID", "ID", oZakaze.DoorID);
            ViewData["ZakazID"] = new SelectList(_context.Set<Zakaz>(), "ID", "ID", oZakaze.ZakazID);
            return View(oZakaze);
        }

        // GET: OZakazes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OZakaze == null)
            {
                return NotFound();
            }

            var oZakaze = await _context.OZakaze
                .Include(o => o.Door)
                .Include(o => o.Zakaz)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (oZakaze == null)
            {
                return NotFound();
            }

            return View(oZakaze);
        }

        // POST: OZakazes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OZakaze == null)
            {
                return Problem("Entity set 'Best_Shop_DoorsContext.OZakaze'  is null.");
            }
            var oZakaze = await _context.OZakaze.FindAsync(id);
            if (oZakaze != null)
            {
                _context.OZakaze.Remove(oZakaze);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OZakazeExists(int id)
        {
          return (_context.OZakaze?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
