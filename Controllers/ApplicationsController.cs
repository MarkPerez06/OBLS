using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Differencing;
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
        public async Task<IActionResult> Create([Bind("Id,Application_Type,Application_PaymentMode,Application_Year,Application_IsGenerateBrgyClearance,Business_Name,Business_TradeName,Business_OrganizationType,Business_Sex,Business_RegistrationNumber,Business_TIN,Business_IsFilipino,Owner_LastName,Owner_FirstName,Owner_MiddleName,Owner_Suffix,MainOffice_Region,MainOffice_Province,MainOffice_CityMunicipality,MainOffice_Brgy,MainOffice_ZipCode,MainOffice_HouseBuildingNumber,MainOffice_BuildingName,MainOffice_LotNumber,MainOffice_BlockNumber,MainOffice_Street,MainOffice_Subdivision,Contact_MobileNumber,Contact_EmailAddress,Contact_TelephoneNumber,BusinessOperation_BusinessActivity,BusinessOperation_OtherBusinessActivity,BusinessOperation_BusinessAreaSqm,BusinessOperation_TotalFloorArea,BusinessOperation_EmployeeMale,BusinessOperation_EmployeeFemale,BusinessOperation_TotalEmployeeWithLGU,BusinessOperation_TotalVanTruck,BusinessOperation_TotalMotorcycle,BusinessOperation_IsOwned,BusinessOperation_HasTaxIncentives,BusinessLocation_Region,BusinessLocation_Province,BusinessLocation_CityMunicipality,BusinessLocation_Brgy,BusinessLocation_ZipCode,BusinessLocation_HouseBuildingNumber,BusinessLocation_BuildingName,BusinessLocation_LotNumber,BusinessLocation_BlockNumber,BusinessLocation_Street,BusinessLocation_Subdivision")] Application application)
        {
            if (ModelState.IsValid)
            {
                application.Id = Guid.NewGuid();
                application.Application_DateTime = DateTime.Now;
                application.Application_Method = "Online";
                application.Application_Status = "Not Complete";
                _context.Add(application);
                await _context.SaveChangesAsync();


                var requirements = _context.Requirements.ToList();

                foreach (var item in requirements)
                {

                    var requirement = new ApplicationRequirements
                    {
                        ApplicationId = application.Id,
                        UserRolesId = item.UserRolesId,
                        Name = item.Name,
                        UrlData = "",
                        IsUpload = item.IsUpload,
                        CreatedDate = DateTime.Now
                    };

                    _context.ApplicationRequirements.Add(requirement);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Edit), new { id = application.Id });
            }
            return View(application);
        }

        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            List<ApplicationRequirements> ARModel = _context.ApplicationRequirements.Where(m => m.ApplicationId == id).OrderBy(m => m.Name).ToList();
            ViewBag.ARModel = ARModel;
            List<LineBusiness> LBModel = _context.LineBusiness.OrderBy(m => m.Code).ToList();
            ViewBag.LBModel = LBModel;
            List<ApplicationLineBusiness> ALBModel = _context.ApplicationLineBusiness.Where(m => m.ApplicationId == id).OrderBy(m => m.CreatedDate).ToList();
            ViewBag.ALBModel = ALBModel;
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Application_Type,Application_PaymentMode,Application_Year,Application_IsGenerateBrgyClearance,Business_Name,Business_TradeName,Business_OrganizationType,Business_Sex,Business_RegistrationNumber,Business_TIN,Business_IsFilipino,Owner_LastName,Owner_FirstName,Owner_MiddleName,Owner_Suffix,MainOffice_Region,MainOffice_Province,MainOffice_CityMunicipality,MainOffice_Brgy,MainOffice_ZipCode,MainOffice_HouseBuildingNumber,MainOffice_BuildingName,MainOffice_LotNumber,MainOffice_BlockNumber,MainOffice_Street,MainOffice_Subdivision,Contact_MobileNumber,Contact_EmailAddress,Contact_TelephoneNumber,BusinessOperation_BusinessActivity,BusinessOperation_OtherBusinessActivity,BusinessOperation_BusinessAreaSqm,BusinessOperation_TotalFloorArea,BusinessOperation_EmployeeMale,BusinessOperation_EmployeeFemale,BusinessOperation_TotalEmployeeWithLGU,BusinessOperation_TotalVanTruck,BusinessOperation_TotalMotorcycle,BusinessOperation_IsOwned,BusinessOperation_HasTaxIncentives,BusinessLocation_Region,BusinessLocation_Province,BusinessLocation_CityMunicipality,BusinessLocation_Brgy,BusinessLocation_ZipCode,BusinessLocation_HouseBuildingNumber,BusinessLocation_BuildingName,BusinessLocation_LotNumber,BusinessLocation_BlockNumber,BusinessLocation_Street,BusinessLocation_Subdivision")] Application application)
        {
            List<ApplicationRequirements> ARModel = _context.ApplicationRequirements.Where(m => m.ApplicationId == id).OrderBy(m => m.Name).ToList();
            ViewBag.ARModel = ARModel;
            List<LineBusiness> LBModel = _context.LineBusiness.OrderBy(m => m.Code).ToList();
            ViewBag.LBModel = LBModel;
            List<ApplicationLineBusiness> ALBModel = _context.ApplicationLineBusiness.Where(m => m.ApplicationId == id).OrderBy(m => m.CreatedDate).ToList();
            ViewBag.ALBModel = ALBModel;
            if (id != application.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    application.Application_DateTime = DateTime.Now;
                    application.Application_Method = "Online";
                    application.Application_Status = "Not Complete";
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

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadFile(Guid Id, Guid AppId, IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var model = await _context.ApplicationRequirements.FindAsync(Id);
            if (model != null)
            {
                // Check if the file is a PDF or an image
                var allowedExtensions = new[] { ".pdf", ".jpg", ".jpeg", ".png" };
                var fileExtension = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtensions.Contains(fileExtension))
                    return BadRequest("Unsupported file type.");

                // Create the ApplicationFormRequirements directory if it doesn't exist
                var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ApplicationFormRequirements");
                if (!Directory.Exists(uploadsPath))
                    Directory.CreateDirectory(uploadsPath);

                // Create a new file name with GUID appended
                var uniqueFileName = $"{Path.GetFileNameWithoutExtension(model.Name)}_{model.ApplicationId}{fileExtension}";
                var filePath = Path.Combine(uploadsPath, uniqueFileName);

                // Save the file to the server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }


                model.UrlData = "/ApplicationFormRequirements/" + uniqueFileName;
                model.CreatedDate = DateTime.Now;
                _context.ApplicationRequirements.Update(model);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Edit), new { id = AppId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteApplicationRequirements(Guid Id, Guid AppId)
        {
            var model = await _context.ApplicationRequirements.FindAsync(Id);
            if (model != null)
            {

                // Construct the file path based on the saved UrlData
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", model.UrlData.TrimStart('/'));

                // Check if the file exists and delete it
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                model.UrlData = "";
                _context.ApplicationRequirements.Update(model);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Edit), new { id = AppId });
        }

        [HttpPost]
        public async Task<IActionResult> AddApplicationLineBusiness(Guid LBId, Guid AppId)
        {
            var model = await _context.LineBusiness.FindAsync(LBId);
            if (model != null)
            {
                var ALBModel = new ApplicationLineBusiness
                {
                    LineBusinessId = model.Id,
                    ApplicationId = AppId,
                    NoOfUnits = "0",
                    CapitalInvestment = "0",
                    GrossIncomeEssential = "0",
                    GrossIncomeNonEssential = "0",
                    SignageBillboard_Capacity = model.SignageBillboard_Capacity,
                    SignageBillboard_NoOfUnits = model.SignageBillboard_NoOfUnits,
                    WeightsAndMeasures_Capacity = model.WeightsAndMeasures_Capacity,
                    WeightsAndMeasures_NoOfUnits = model.WeightsAndMeasures_NoOfUnits,
                    CreatedDate = DateTime.Now
                };
                _context.ApplicationLineBusiness.Update(ALBModel);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Edit), new { id = AppId });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateApplicationLineBusiness(Guid Id, Guid AppId,
            string NoOfUnits, string CapitalInvestment, string GrossIncomeEssential, string GrossIncomeNonEssential,
            string SignageBillboard_Capacity, string SignageBillboard_NoOfUnits, string WeightsAndMeasures_Capacity, string WeightsAndMeasures_NoOfUnits)
        {
            var model = await _context.ApplicationLineBusiness.FindAsync(Id);
            if (model != null)
            {
                model.NoOfUnits = NoOfUnits;
                model.CapitalInvestment = CapitalInvestment;
                model.GrossIncomeEssential = GrossIncomeEssential;
                model.GrossIncomeNonEssential = GrossIncomeNonEssential;
                model.SignageBillboard_Capacity = SignageBillboard_Capacity;
                model.SignageBillboard_NoOfUnits = SignageBillboard_NoOfUnits;
                model.WeightsAndMeasures_Capacity = WeightsAndMeasures_Capacity;
                model.WeightsAndMeasures_NoOfUnits = WeightsAndMeasures_NoOfUnits;
                _context.ApplicationLineBusiness.Update(model);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Edit), new { id = AppId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteApplicationLineBusiness(Guid Id, Guid AppId)
        {
            var model = await _context.ApplicationLineBusiness.FindAsync(Id);
            if (model != null)
            {
                _context.ApplicationLineBusiness.Remove(model);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Edit), new { id = AppId });
        }


    }
}
