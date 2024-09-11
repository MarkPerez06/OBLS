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
    public class ApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Applications
        public async Task<IActionResult> Index()
        {
              return _context.Application != null ? 
                          View(await _context.Application.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Application'  is null.");
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Application == null)
            {
                return NotFound();
            }

            var application = await _context.Application
                .FirstOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // GET: Applications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Applications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Application_Type,Application_PaymentMode,Application_Year,Application_Method,Application_Status,Application_DateTime,Application_IsGenerateBrgyClearance,Business_Name,Business_TradeName,Business_OrganizationType,Business_Sex,Business_RegistrationNumber,Business_TIN,Business_IsFilipino,Owner_LastName,Owner_FirstName,Owner_MiddleName,Owner_Suffix,MainOffice_Region,MainOffice_Province,MainOffice_CityMunicipality,MainOffice_Brgy,MainOffice_ZipCode,MainOffice_HouseBuildingNumber,MainOffice_BuildingName,MainOffice_LotNumber,MainOffice_BlockNumber,MainOffice_Street,MainOffice_Subdivision,Contact_MobileNumber,Contact_EmailAddress,Contact_TelephoneNumber,BusinessOperation_BusinessActivity,BusinessOperation_OtherBusinessActivity,BusinessOperation_BusinessAreaSqm,BusinessOperation_TotalFloorArea,BusinessOperation_EmployeeMale,BusinessOperation_EmployeeFemale,BusinessOperation_TotalEmployeeWithLGU,BusinessOperation_TotalVanTruck,BusinessOperation_TotalMotorcycle,BusinessOperation_IsOwned,BusinessOperation_HasTaxIncentives,BusinessLocation_Region,BusinessLocation_Province,BusinessLocation_CityMunicipality,BusinessLocation_Brgy,BusinessLocation_ZipCode,BusinessLocation_HouseBuildingNumber,BusinessLocation_BuildingName,BusinessLocation_LotNumber,BusinessLocation_BlockNumber,BusinessLocation_Street,BusinessLocation_Subdivision")] Application application)
        {
            if (ModelState.IsValid)
            {
                application.Id = Guid.NewGuid();
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(application);
        }

        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Application == null)
            {
                return NotFound();
            }

            var application = await _context.Application.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Application_Type,Application_PaymentMode,Application_Year,Application_Method,Application_Status,Application_DateTime,Application_IsGenerateBrgyClearance,Business_Name,Business_TradeName,Business_OrganizationType,Business_Sex,Business_RegistrationNumber,Business_TIN,Business_IsFilipino,Owner_LastName,Owner_FirstName,Owner_MiddleName,Owner_Suffix,MainOffice_Region,MainOffice_Province,MainOffice_CityMunicipality,MainOffice_Brgy,MainOffice_ZipCode,MainOffice_HouseBuildingNumber,MainOffice_BuildingName,MainOffice_LotNumber,MainOffice_BlockNumber,MainOffice_Street,MainOffice_Subdivision,Contact_MobileNumber,Contact_EmailAddress,Contact_TelephoneNumber,BusinessOperation_BusinessActivity,BusinessOperation_OtherBusinessActivity,BusinessOperation_BusinessAreaSqm,BusinessOperation_TotalFloorArea,BusinessOperation_EmployeeMale,BusinessOperation_EmployeeFemale,BusinessOperation_TotalEmployeeWithLGU,BusinessOperation_TotalVanTruck,BusinessOperation_TotalMotorcycle,BusinessOperation_IsOwned,BusinessOperation_HasTaxIncentives,BusinessLocation_Region,BusinessLocation_Province,BusinessLocation_CityMunicipality,BusinessLocation_Brgy,BusinessLocation_ZipCode,BusinessLocation_HouseBuildingNumber,BusinessLocation_BuildingName,BusinessLocation_LotNumber,BusinessLocation_BlockNumber,BusinessLocation_Street,BusinessLocation_Subdivision")] Application application)
        {
            if (id != application.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.Id))
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
            return View(application);
        }

        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Application == null)
            {
                return NotFound();
            }

            var application = await _context.Application
                .FirstOrDefaultAsync(m => m.Id == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Application == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Application'  is null.");
            }
            var application = await _context.Application.FindAsync(id);
            if (application != null)
            {
                _context.Application.Remove(application);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationExists(Guid id)
        {
          return (_context.Application?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
