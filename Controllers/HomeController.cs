using OBLS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace OBLS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public HomeController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
