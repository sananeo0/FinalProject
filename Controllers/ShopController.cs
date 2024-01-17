using FinalProject.Data;
using FinalProject.Entities;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ShopController(AppDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public IActionResult Index(int page, int productsPerPage, string order = "desc")
        {
            ViewBag.Brands = _dbContext.Brands.ToList();
            ViewBag.Categories = _dbContext.Categories.ToList();
            ViewBag.Colors = _dbContext.Color.ToList();
            ViewBag.Products = _dbContext.Products.ToList();

            if (page <= 0) page = 1;

            productsPerPage = 3;

            var productsCount = _dbContext.Products.Count();

            int totalPageCount = (int)Math.Ceiling((decimal)productsCount / productsPerPage);

            var products = order switch
            {
                "desc" => _dbContext.Products.OrderByDescending(x => x.Id),
                "asc" => _dbContext.Products.OrderBy(x => x.Id),
                _ => _dbContext.Products.OrderByDescending(x => x.Id)
            };

            var model = new ShopIndexVM
            {

                Products = products
                .Skip((page - 1) * productsPerPage)
                .Take(productsPerPage)
                .ToList(),

                TotalPageCount = totalPageCount,
                CurrentPage = page,
                TotalProducts = products.Count()

            };

            return View(model);
        }
        public IActionResult ProductDetails(int? id)
        {
            if (id == null) return NotFound();

            var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);

            if (product == null) return NotFound();

            var model = new ShopIndexVM
            {
                Products = new List<Product> { product }
            };
            return View(model);
        }
    }
}
