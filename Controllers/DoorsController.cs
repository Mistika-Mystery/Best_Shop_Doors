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
    public class DoorsController : Controller
    {
        private readonly Best_Shop_DoorsContext _context;

        public DoorsController(Best_Shop_DoorsContext context)
        {
            _context = context;
        }

        // GET: Doors
        public async Task<IActionResult> Index()
        {
            var best_Shop_DoorsContext = _context.Door.Include(d => d.Color).Include(d => d.Material).Include(d => d.Proizvoditel).Include(d => d.Tip);
            return View(await best_Shop_DoorsContext.ToListAsync());
        }

        // GET: Doors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Door == null)
            {
                return NotFound();
            }

            var door = await _context.Door
                .Include(d => d.Color)
                .Include(d => d.Material)
                .Include(d => d.Proizvoditel)
                .Include(d => d.Tip)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (door == null)
            {
                return NotFound();
            }

            return View(door);
        }

        // GET: Doors/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["ColorID"] = new SelectList(_context.Color, "ID", "ID");
            ViewData["MaterialID"] = new SelectList(_context.Set<Material>(), "ID", "ID");
            ViewData["ProizvoditelID"] = new SelectList(_context.Set<Proizvoditel>(), "ID", "ID");
            ViewData["TipID"] = new SelectList(_context.Set<Tip>(), "ID", "ID");
            return View();
        }

        // POST: Doors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Price,TipID,MaterialID,ColorID,ProizvoditelID,Foto,Opisanie")] Door door)
        {
            if (ModelState.IsValid)
            {
                _context.Add(door);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ColorID"] = new SelectList(_context.Color, "ID", "ID", door.ColorID);
            ViewData["MaterialID"] = new SelectList(_context.Set<Material>(), "ID", "ID", door.MaterialID);
            ViewData["ProizvoditelID"] = new SelectList(_context.Set<Proizvoditel>(), "ID", "ID", door.ProizvoditelID);
            ViewData["TipID"] = new SelectList(_context.Set<Tip>(), "ID", "ID", door.TipID);
            return View(door);
        }

        // GET: Doors/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Door == null)
            {
                return NotFound();
            }

            var door = await _context.Door.FindAsync(id);
            if (door == null)
            {
                return NotFound();
            }
            ViewData["ColorID"] = new SelectList(_context.Color, "ID", "ID", door.ColorID);
            ViewData["MaterialID"] = new SelectList(_context.Set<Material>(), "ID", "ID", door.MaterialID);
            ViewData["ProizvoditelID"] = new SelectList(_context.Set<Proizvoditel>(), "ID", "ID", door.ProizvoditelID);
            ViewData["TipID"] = new SelectList(_context.Set<Tip>(), "ID", "ID", door.TipID);
            return View(door);
        }

        // POST: Doors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Price,TipID,MaterialID,ColorID,ProizvoditelID,Foto,Opisanie")] Door door)
        {
            if (id != door.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(door);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoorExists(door.ID))
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
            ViewData["ColorID"] = new SelectList(_context.Color, "ID", "ID", door.ColorID);
            ViewData["MaterialID"] = new SelectList(_context.Set<Material>(), "ID", "ID", door.MaterialID);
            ViewData["ProizvoditelID"] = new SelectList(_context.Set<Proizvoditel>(), "ID", "ID", door.ProizvoditelID);
            ViewData["TipID"] = new SelectList(_context.Set<Tip>(), "ID", "ID", door.TipID);
            return View(door);
        }

        // GET: Doors/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Door == null)
            {
                return NotFound();
            }

            var door = await _context.Door
                .Include(d => d.Color)
                .Include(d => d.Material)
                .Include(d => d.Proizvoditel)
                .Include(d => d.Tip)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (door == null)
            {
                return NotFound();
            }

            return View(door);
        }

        // POST: Doors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Door == null)
            {
                return Problem("Entity set 'Best_Shop_DoorsContext.Door'  is null.");
            }
            var door = await _context.Door.FindAsync(id);
            if (door != null)
            {
                _context.Door.Remove(door);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoorExists(int id)
        {
          return (_context.Door?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
