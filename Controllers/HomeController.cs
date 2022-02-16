using Microsoft.AspNetCore.Mvc;

namespace _4Shapes.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Shapes");
        }
    }
}
