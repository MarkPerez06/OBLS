using Microsoft.AspNetCore.Mvc;

namespace OBLS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
