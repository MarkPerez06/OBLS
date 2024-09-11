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
            return View();
        }
    }
}
