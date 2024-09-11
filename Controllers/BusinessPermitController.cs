using Microsoft.AspNetCore.Mvc;

namespace OBLS.Controllers
{
    public class BusinessPermitController : Controller
    {
        public IActionResult NewApplication()
        {
            return View();
        }
    }
}
