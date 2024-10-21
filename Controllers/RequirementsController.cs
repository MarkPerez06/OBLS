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
    public class RequirementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequirementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Requirements
        public async Task<IActionResult> Index()
        {
              return _context.Requirements != null ? 
                          View(await _context.Requirements.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Requirements'  is null.");
        }

        // GET: Requirements/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Requirements == null)
            {
                return NotFound();
            }

            var requirements = await _context.Requirements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requirements == null)
            {
                return NotFound();
            }

            return View(requirements);
        }

        // GET: Requirements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Requirements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserRolesId,Name,IsUpload")] Requirements requirements)
        {
            if (ModelState.IsValid)
            {
                requirements.Id = Guid.NewGuid();
                _context.Add(requirements);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requirements);
        }

        // GET: Requirements/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Requirements == null)
            {
                return NotFound();
            }

            var requirements = await _context.Requirements.FindAsync(id);
            if (requirements == null)
            {
                return NotFound();
            }
            return View(requirements);
        }

        // POST: Requirements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,UserRolesId,Name,IsUpload")] Requirements requirements)
        {
            if (id != requirements.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requirements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequirementsExists(requirements.Id))
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
            return View(requirements);
        }

        // GET: Requirements/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Requirements == null)
            {
                return NotFound();
            }

            var requirements = await _context.Requirements
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requirements == null)
            {
                return NotFound();
            }

            return View(requirements);
        }

        // POST: Requirements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Requirements == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Requirements'  is null.");
            }
            var requirements = await _context.Requirements.FindAsync(id);
            if (requirements != null)
            {
                _context.Requirements.Remove(requirements);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequirementsExists(Guid id)
        {
          return (_context.Requirements?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
