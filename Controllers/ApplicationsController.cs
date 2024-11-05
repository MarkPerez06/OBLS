using System;
using System.Collections.Generic;
using System.Data;
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
using OBLS.Static;


namespace OBLS.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        public ApplicationsController(ApplicationDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }
        public string GenerateBusinessID()
        {
            // Get the current date and time
            DateTime now = DateTime.Now;

            // Convert date and time to a format that creates a unique 7-digit number
            // Example: Combine year, day, and milliseconds
            string businessID = $"{now.ToString("yy")}{now.DayOfYear}{now.Millisecond:D3}".PadLeft(7, '0');

            // If the result exceeds 7 digits, truncate it
            if (businessID.Length > 7)
            {
                businessID = businessID.Substring(0, 7);
            }

            return businessID;
        }


        static string GenerateTrackingNumber()
        {
            string prefix = "RBPA"; // Fixed prefix
            string randomNumber = GenerateRandomNumber(10); // Generate a 10-digit random number
            string currentDate = DateTime.Now.ToString("yyyy-MM"); // Current year and month (e.g., 2024-10)
            string sequenceNumber = GenerateSequenceNumber(6); // Generate a 6-digit sequence number

            return $"{prefix}-{randomNumber}-{currentDate}-{sequenceNumber}";
        }

        static string GenerateRandomNumber(int length)
        {
            Random random = new Random();
            string result = "";
            for (int i = 0; i < length; i++)
            {
                result += random.Next(0, 10).ToString(); // Append a random digit (0-9)
            }
            return result;
        }

        static string GenerateSequenceNumber(int length)
        {
            Random random = new Random();
            string result = random.Next(1, (int)Math.Pow(10, length)).ToString().PadLeft(length, '0'); // Zero-padded sequence number
            return result;
        }

        // GET: Applications
        public async Task<IActionResult> Index()
        {
            return _context.Application != null ?
                          View(await _context.Application.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Application'  is null.");
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> BusinessPermit(Guid? id)
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
        public async Task<IActionResult> Create([Bind("Id,Application_Type,Application_PaymentMode,Application_Year,Application_IsGenerateBrgyClearance,Business_Name,Business_TradeName,Business_OrganizationType,Business_Sex,Business_RegistrationNumber,Business_TIN,Business_IsFilipino,Owner_LastName,Owner_FirstName,Owner_MiddleName,Owner_Suffix,MainOffice_Region,MainOffice_Province,MainOffice_CityMunicipality,MainOffice_Brgy,MainOffice_ZipCode,MainOffice_HouseBuildingNumber,MainOffice_BuildingName,MainOffice_LotNumber,MainOffice_BlockNumber,MainOffice_Street,MainOffice_Subdivision,Contact_MobileNumber,Contact_EmailAddress,Contact_TelephoneNumber,BusinessOperation_BusinessActivity,BusinessOperation_OtherBusinessActivity,BusinessOperation_BusinessAreaSqm,BusinessOperation_TotalFloorArea,BusinessOperation_EmployeeMale,BusinessOperation_EmployeeFemale,BusinessOperation_TotalEmployeeWithLGU,BusinessOperation_TotalVanTruck,BusinessOperation_TotalMotorcycle,BusinessOperation_IsOwned,BusinessOperation_TaxDeclarationNo,BusinessOperation_PropertyIdentificationNo,BusinessOperation_HasTaxIncentives,BusinessOperation_PleaseSpecifyTheEntity,BusinessLocation_Region,BusinessLocation_Province,BusinessLocation_CityMunicipality,BusinessLocation_Brgy,BusinessLocation_ZipCode,BusinessLocation_HouseBuildingNumber,BusinessLocation_BuildingName,BusinessLocation_LotNumber,BusinessLocation_BlockNumber,BusinessLocation_Street,BusinessLocation_Subdivision,Latitude,Longitude")] Application application)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.Where(m => m.UserName == User.Identity.Name).FirstOrDefault();

                application.Id = Guid.NewGuid();
                application.Tracking_Number = GenerateTrackingNumber();
                application.Application_DateTime = DateTime.Now;
                application.Application_Method = "Online";
                application.Application_Status = "Not Complete";
                application.UserId = user.Id;

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
            List<ApplicationRequirements> ARModel = _context.ApplicationRequirements.Where(m => m.ApplicationId == id).OrderBy(m => m.UserRolesId).ThenBy(m => m.Name).ToList();
            ViewBag.ARModel = ARModel;
            List<LineBusiness> LBModel = _context.LineBusiness.OrderBy(m => m.Code).ToList();
            ViewBag.LBModel = LBModel;
            List<ApplicationLineBusiness> ALBModel = _context.ApplicationLineBusiness.Where(m => m.ApplicationId == id).OrderBy(m => m.CreatedDate).ToList();
            ViewBag.ALBModel = ALBModel;
            List<ApplicationSignatories> ASModel = _context.ApplicationSignatories.Where(m => m.ApplicationId == id).OrderBy(m => m.CreatedDate).ToList();
            ViewBag.ASModel = ASModel;
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Application_Type,Application_PaymentMode,Application_Year,Application_Method,Application_Status,Application_DateTime,Application_IsGenerateBrgyClearance,Tracking_Number,Business_IDNumber,Business_Name,Business_TradeName,Business_OrganizationType,Business_Sex,Business_RegistrationNumber,Business_TIN,Business_IsFilipino,Owner_LastName,Owner_FirstName,Owner_MiddleName,Owner_Suffix,MainOffice_Region,MainOffice_Province,MainOffice_CityMunicipality,MainOffice_Brgy,MainOffice_ZipCode,MainOffice_HouseBuildingNumber,MainOffice_BuildingName,MainOffice_LotNumber,MainOffice_BlockNumber,MainOffice_Street,MainOffice_Subdivision,Contact_MobileNumber,Contact_EmailAddress,Contact_TelephoneNumber,BusinessOperation_BusinessActivity,BusinessOperation_OtherBusinessActivity,BusinessOperation_BusinessAreaSqm,BusinessOperation_TotalFloorArea,BusinessOperation_EmployeeMale,BusinessOperation_EmployeeFemale,BusinessOperation_TotalEmployeeWithLGU,BusinessOperation_TotalVanTruck,BusinessOperation_TotalMotorcycle,BusinessOperation_IsOwned,BusinessOperation_TaxDeclarationNo,BusinessOperation_PropertyIdentificationNo,BusinessOperation_HasTaxIncentives,BusinessOperation_PleaseSpecifyTheEntity,BusinessLocation_Region,BusinessLocation_Province,BusinessLocation_CityMunicipality,BusinessLocation_Brgy,BusinessLocation_ZipCode,BusinessLocation_HouseBuildingNumber,BusinessLocation_BuildingName,BusinessLocation_LotNumber,BusinessLocation_BlockNumber,BusinessLocation_Street,BusinessLocation_Subdivision,Latitude,Longitude,Permit_ExpiredDate,Permit_DateRelease,Permit_Amount,Permit_IsPaid,Permit_Comments")] Application application)
        {
            List<ApplicationRequirements> ARModel = _context.ApplicationRequirements.Where(m => m.ApplicationId == id).OrderBy(m => m.UserRolesId).ThenBy(m => m.Name).ToList();
            ViewBag.ARModel = ARModel;
            List<LineBusiness> LBModel = _context.LineBusiness.OrderBy(m => m.Code).ToList();
            ViewBag.LBModel = LBModel;
            List<ApplicationLineBusiness> ALBModel = _context.ApplicationLineBusiness.Where(m => m.ApplicationId == id).OrderBy(m => m.CreatedDate).ToList();
            ViewBag.ALBModel = ALBModel;
            List<ApplicationSignatories> ASModel = _context.ApplicationSignatories.Where(m => m.ApplicationId == id).OrderBy(m => m.CreatedDate).ToList();
            ViewBag.ASModel = ASModel;
            if (id != application.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var requirements = _context.Requirements.ToList();

                    foreach (var item in requirements)
                    {
                        var AR = _context.ApplicationRequirements.Where(m => m.ApplicationId == id && m.UserRolesId == item.UserRolesId && m.Name == item.Name).ToList();
                        if (AR.Count == 0)
                        {
                            var requirement = new ApplicationRequirements
                            {
                                ApplicationId = id,
                                UserRolesId = item.UserRolesId,
                                Name = item.Name,
                                UrlData = "",
                                IsUpload = item.IsUpload,
                                CreatedDate = DateTime.Now
                            };
                            _context.ApplicationRequirements.Add(requirement);
                            await _context.SaveChangesAsync();
                        }
                    }
                    var user = _context.Users.Where(m => m.UserName == User.Identity.Name).FirstOrDefault();

                    application.UserId = user.Id;
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
                return RedirectToAction(nameof(Edit), new { id = application.Id });
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

        [HttpPost]
        public async Task<IActionResult> Payment(Guid Id, decimal Permit_Amount)
        {
            var model = await _context.Application.FindAsync(Id);
            if (model != null)
            {
                model.Permit_Amount = Permit_Amount;
                _context.Application.Update(model);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Edit), new { id = Id });

        }

        [HttpPost]
        public async Task<IActionResult> Comments(Guid Id, string Permit_Comments)
        {
            var model = await _context.Application.FindAsync(Id);
            if (model != null)
            {
                model.Permit_Comments = Permit_Comments;
                _context.Application.Update(model);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Edit), new { id = Id });

        }

        [HttpPost]
        public async Task<IActionResult> Declined(Guid Id)
        {
            var model = await _context.Application.FindAsync(Id);
            if (model != null)
            {
                model.Application_Status = "Declined";
                _context.Application.Update(model);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Edit), new { id = Id });
        }

        [HttpPost]
        public async Task<IActionResult> Cancelled(Guid Id)
        {
            var model = await _context.Application.FindAsync(Id);
            if (model != null)
            {
                model.Application_Status = "Cancelled Permit";
                _context.Application.Update(model);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Edit), new { id = Id });

        }

        [HttpPost]
        public async Task<IActionResult> LicenseIssuedApplication(Guid Id, string? FullName, DateTime Permit_DateRelease, DateTime Permit_ExpiredDate)
        {
            var user = await _signInManager.UserManager.FindByNameAsync(User.Identity?.Name);
            var UserRoleId = user.SecurityStamp;

            var model = await _context.Application.FindAsync(Id);
            if (model != null)
            {
                if (UserRoleId == UserRoles.MunicipalMayor.Id)
                {
                    if (model.Application_Status == "For Issuance")
                    {
                        model.Permit_DateRelease = Permit_DateRelease;
                        model.Permit_ExpiredDate = Permit_ExpiredDate;
                        model.Application_Status = "License Issued";
                        model.Business_IDNumber = GenerateBusinessID();
                    }

                    var AS = new ApplicationSignatories
                    {
                        ApplicationId = Id,
                        UserRolesId = new Guid(UserRoleId),
                        FullName = FullName,
                        Role = UserRoles.MunicipalMayor.Name,
                        Department = "OFFICE OF THE MUNICIPAL MAYOR",
                        CreatedDate = DateTime.Now
                    };
                    _context.ApplicationSignatories.Add(AS);
                    await _context.SaveChangesAsync();
                }
                _context.Application.Update(model);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> SubmitApplication(Guid Id, string? FullName)
        {
            var user = await _signInManager.UserManager.FindByNameAsync(User.Identity?.Name);
            var UserRoleId = user.SecurityStamp;

            var model = await _context.Application.FindAsync(Id);
            if (model != null)
            {
                if (UserRoleId == UserRoles.Applicant.Id)
                {
                    model.Application_Status = "Submitted";
                }



                if (UserRoleId == UserRoles.BarangayCaptain.Id)
                {
                    model.Application_Status = "For Verification";

                    var AS = new ApplicationSignatories
                    {
                        ApplicationId = Id,
                        UserRolesId = new Guid(UserRoleId),
                        FullName = FullName,
                        Role = UserRoles.BarangayCaptain.Name,
                        Department = "Barangay " + model.BusinessLocation_Brgy,
                        CreatedDate = DateTime.Now
                    };
                    _context.ApplicationSignatories.Add(AS);
                    await _context.SaveChangesAsync();
                }

                if (UserRoleId == UserRoles.BIRCollectionOfficer.Id)
                {
                    model.Application_Status = "For Verification";

                    var AS = new ApplicationSignatories
                    {
                        ApplicationId = Id,
                        UserRolesId = new Guid(UserRoleId),
                        FullName = FullName,
                        Role = UserRoles.BIRCollectionOfficer.Name,
                        Department = "OFFICER OF THE BIR COLLECTION OFFICE",
                        CreatedDate = DateTime.Now
                    };
                    _context.ApplicationSignatories.Add(AS);
                    await _context.SaveChangesAsync();
                }

                if (UserRoleId == UserRoles.ChiefOfPolice.Id)
                {
                    model.Application_Status = "For Verification";

                    var AS = new ApplicationSignatories
                    {
                        ApplicationId = Id,
                        UserRolesId = new Guid(UserRoleId),
                        FullName = FullName,
                        Role = UserRoles.ChiefOfPolice.Name,
                        Department = "OFFICE OF THE STATION COMMANDER",
                        CreatedDate = DateTime.Now
                    };
                    _context.ApplicationSignatories.Add(AS);
                    await _context.SaveChangesAsync();
                }

                if (UserRoleId == UserRoles.MENROOfficer.Id)
                {
                    model.Application_Status = "For Verification";

                    var AS = new ApplicationSignatories
                    {
                        ApplicationId = Id,
                        UserRolesId = new Guid(UserRoleId),
                        FullName = FullName,
                        Role = UserRoles.MENROOfficer.Name,
                        Department = "OFFICE OF THE MUNICIPAL ENVIRONMENT & NATURAL RESOURCES",
                        CreatedDate = DateTime.Now
                    };
                    _context.ApplicationSignatories.Add(AS);
                    await _context.SaveChangesAsync();
                }

                if (UserRoleId == UserRoles.MunicipalEngineer.Id)
                {
                    model.Application_Status = "For Verification";

                    var AS = new ApplicationSignatories
                    {
                        ApplicationId = Id,
                        UserRolesId = new Guid(UserRoleId),
                        FullName = FullName,
                        Role = UserRoles.MunicipalEngineer.Name,
                        Department = "OFFICE OF THE BUILDING OFFICIAL",
                        CreatedDate = DateTime.Now
                    };
                    _context.ApplicationSignatories.Add(AS);
                    await _context.SaveChangesAsync();
                }

                if (UserRoleId == UserRoles.MunicipalFireMarshall.Id)
                {
                    model.Application_Status = "For Verification";

                    var AS = new ApplicationSignatories
                    {
                        ApplicationId = Id,
                        UserRolesId = new Guid(UserRoleId),
                        FullName = FullName,
                        Role = UserRoles.MunicipalFireMarshall.Name,
                        Department = "OFFICE OF THE FIRE MARSHALL",
                        CreatedDate = DateTime.Now
                    };
                    _context.ApplicationSignatories.Add(AS);
                    await _context.SaveChangesAsync();
                }

                if (UserRoleId == UserRoles.MunicipalHealthOfficer.Id)
                {
                    model.Application_Status = "For Verification";

                    var AS = new ApplicationSignatories
                    {
                        ApplicationId = Id,
                        UserRolesId = new Guid(UserRoleId),
                        FullName = FullName,
                        Role = UserRoles.MunicipalHealthOfficer.Name,
                        Department = "OFFICE OF THE RURAL HEALTH OFFICER",
                        CreatedDate = DateTime.Now
                    };
                    _context.ApplicationSignatories.Add(AS);
                    await _context.SaveChangesAsync();
                }

                if (UserRoleId == UserRoles.SanitaryHealthOfficer.Id)
                {
                    model.Application_Status = "For Verification";

                    var AS = new ApplicationSignatories
                    {
                        ApplicationId = Id,
                        UserRolesId = new Guid(UserRoleId),
                        FullName = FullName,
                        Role = UserRoles.SanitaryHealthOfficer.Name,
                        Department = "OFFICE OF THE SANITARY HEALTH OFFICER",
                        CreatedDate = DateTime.Now
                    };
                    _context.ApplicationSignatories.Add(AS);
                    await _context.SaveChangesAsync();
                }

                if (UserRoleId == UserRoles.MunicipalTreasurer.Id)
                {
                    if (model.Application_Status == "For Payment")
                    {
                        model.Application_Status = "For Issuance";
                        model.Permit_IsPaid = true;
                    }

                    var AS = new ApplicationSignatories
                    {
                        ApplicationId = Id,
                        UserRolesId = new Guid(UserRoleId),
                        FullName = FullName,
                        Role = UserRoles.MunicipalTreasurer.Name,
                        Department = "OFFICE OF THE MUNICIPAL TREASURER OFFICER",
                        CreatedDate = DateTime.Now
                    };
                    _context.ApplicationSignatories.Add(AS);
                    await _context.SaveChangesAsync();
                }

                if (UserRoleId == UserRoles.MunicipalMayor.Id)
                {
                    if (model.Application_Status == "For Issuance")
                    {
                        model.Application_Status = "License Issued";
                        model.Business_IDNumber = GenerateBusinessID();
                    }

                    var AS = new ApplicationSignatories
                    {
                        ApplicationId = Id,
                        UserRolesId = new Guid(UserRoleId),
                        FullName = FullName,
                        Role = UserRoles.MunicipalMayor.Name,
                        Department = "OFFICE OF THE MUNICIPAL MAYOR",
                        CreatedDate = DateTime.Now
                    };
                    _context.ApplicationSignatories.Add(AS);
                    await _context.SaveChangesAsync();
                }

                var ASModel = _context.ApplicationSignatories.Where(m => m.ApplicationId == Id).ToList();
                if (ASModel.Count == 8)
                {
                    model.Application_Status = "For Payment";
                }

                _context.Application.Update(model);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // Map
        [Route("Map")]
        public IActionResult Map()
        {
            return View();
        }

        public async Task<JsonResult> GetAppBusinesses(Guid AppId)
        {
            var businesses = await _context.Application.Where(m => m.Id == AppId)
                .Select(b => new
                {
                    b.Latitude,
                    b.Longitude
                })
                .ToListAsync();

            return Json(businesses);
        }

        public async Task<JsonResult> GetBusinesses()
        {
            var businesses = await _context.Application
                .Select(b => new
                {
                    b.Business_Name,
                    Address =
                        (b.BusinessLocation_BlockNumber != null ? "Block No.: " + b.BusinessLocation_BlockNumber + ", " : "") +
                        (b.BusinessLocation_LotNumber != null ? "Lot No.: " + b.BusinessLocation_LotNumber + ", " : "") +
                        (b.BusinessLocation_BuildingName != null ? "Building Name: " + b.BusinessLocation_BuildingName + ", " : "") +
                        (b.BusinessLocation_HouseBuildingNumber != null ? "Building No.: " + b.BusinessLocation_HouseBuildingNumber + ", " : "") +
                        b.BusinessLocation_Brgy + ", " +
                        b.BusinessLocation_CityMunicipality + ", " +
                        b.BusinessLocation_Province + ", " +
                        b.BusinessLocation_Region + ", Philippines",
                    OwnerName = b.Owner_FirstName + " " + b.Owner_MiddleName + " " + b.Owner_LastName + " " + b.Owner_Suffix,
                    b.Latitude,
                    b.Longitude
                })
                .ToListAsync();

            return Json(businesses);
        }


    }
}
