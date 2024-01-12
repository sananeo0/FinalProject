using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers.Home
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
