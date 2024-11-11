using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OBLS.Data;
using OBLS.Models;

namespace OBLS.Controllers
{
    public class TaxesFeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaxesFeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaxesFees
        public async Task<IActionResult> Index()
        {
              return _context.TaxesFees != null ? 
                          View(await _context.TaxesFees.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TaxesFees'  is null.");
        }

        // GET: TaxesFees/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.TaxesFees == null)
            {
                return NotFound();
            }

            var taxesFees = await _context.TaxesFees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxesFees == null)
            {
                return NotFound();
            }

            return View(taxesFees);
        }

        // GET: TaxesFees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaxesFees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,IsActive,DateCreated")] TaxesFees taxesFees)
        {
            if (ModelState.IsValid)
            {
                taxesFees.Id = Guid.NewGuid();
                _context.Add(taxesFees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taxesFees);
        }

        // GET: TaxesFees/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.TaxesFees == null)
            {
                return NotFound();
            }

            var taxesFees = await _context.TaxesFees.FindAsync(id);
            if (taxesFees == null)
            {
                return NotFound();
            }
            return View(taxesFees);
        }

        // POST: TaxesFees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Price,IsActive,DateCreated")] TaxesFees taxesFees)
        {
            if (id != taxesFees.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taxesFees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaxesFeesExists(taxesFees.Id))
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
            return View(taxesFees);
        }

        // GET: TaxesFees/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.TaxesFees == null)
            {
                return NotFound();
            }

            var taxesFees = await _context.TaxesFees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxesFees == null)
            {
                return NotFound();
            }

            return View(taxesFees);
        }

        // POST: TaxesFees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.TaxesFees == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TaxesFees'  is null.");
            }
            var taxesFees = await _context.TaxesFees.FindAsync(id);
            if (taxesFees != null)
            {
                _context.TaxesFees.Remove(taxesFees);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaxesFeesExists(Guid id)
        {
          return (_context.TaxesFees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
