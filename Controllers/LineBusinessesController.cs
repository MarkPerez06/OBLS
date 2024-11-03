using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OBLS.Data;
using OBLS.Models;
using OBLS.Static;

namespace OBLS.Controllers
{
    public class LineBusinessesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LineBusinessesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LineBusinesses
        public async Task<IActionResult> Index()
        {
            var user = _context.Users.Where(m => m.UserName == User.Identity.Name).FirstOrDefault();
            if (User.Identity.IsAuthenticated && user.SecurityStamp == UserRoles.Administrator.Id)
            {
                return _context.LineBusiness != null ?
                          View(await _context.LineBusiness.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.LineBusiness'  is null.");
            }
            else
            {
                return Redirect("~/Identity/Account/Login");
            }
        }

        // GET: LineBusinesses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.LineBusiness == null)
            {
                return NotFound();
            }

            var lineBusiness = await _context.LineBusiness
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lineBusiness == null)
            {
                return NotFound();
            }

            return View(lineBusiness);
        }

        // GET: LineBusinesses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LineBusinesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Description,SignageBillboard_Capacity,SignageBillboard_NoOfUnits,WeightsAndMeasures_Capacity,WeightsAndMeasures_NoOfUnits")] LineBusiness lineBusiness)
        {
            if (ModelState.IsValid)
            {
                lineBusiness.Id = Guid.NewGuid();
                _context.Add(lineBusiness);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lineBusiness);
        }

        // GET: LineBusinesses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.LineBusiness == null)
            {
                return NotFound();
            }

            var lineBusiness = await _context.LineBusiness.FindAsync(id);
            if (lineBusiness == null)
            {
                return NotFound();
            }
            return View(lineBusiness);
        }

        // POST: LineBusinesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Code,Description,SignageBillboard_Capacity,SignageBillboard_NoOfUnits,WeightsAndMeasures_Capacity,WeightsAndMeasures_NoOfUnits")] LineBusiness lineBusiness)
        {
            if (id != lineBusiness.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lineBusiness);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineBusinessExists(lineBusiness.Id))
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
            return View(lineBusiness);
        }

        // GET: LineBusinesses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.LineBusiness == null)
            {
                return NotFound();
            }

            var lineBusiness = await _context.LineBusiness
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lineBusiness == null)
            {
                return NotFound();
            }

            return View(lineBusiness);
        }

        // POST: LineBusinesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.LineBusiness == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LineBusiness'  is null.");
            }
            var lineBusiness = await _context.LineBusiness.FindAsync(id);
            if (lineBusiness != null)
            {
                _context.LineBusiness.Remove(lineBusiness);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LineBusinessExists(Guid id)
        {
          return (_context.LineBusiness?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
