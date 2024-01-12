using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Areas.Admin.Controllers.Product
{
    public class ProductController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
