using OBLS.Data;
using OBLS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace OBLS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<MenuProductsController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public HomeController(ApplicationDbContext context, ILogger<MenuProductsController> logger, IWebHostEnvironment environment)
        {
            _context = context;
            _logger = logger;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var Persons = _context.Persons.Where(m => m.Email == User.Identity.Name).FirstOrDefault();
            if (Persons != null)
            {
                ViewBag.Persons = Persons;
            }
            else
            {
                Persons Model = new Persons();
                Model.IsAdmin = false;
                Model.IsStaff = false;
                Model.IsMember = true;
                ViewBag.Persons = Model;
            }
            return View();
        }
    }
}
