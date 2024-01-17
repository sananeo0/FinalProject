using FinalProject.Areas.Admin.Models;
using FinalProject.Data;
using FinalProject.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Areas.Admin.Controllers.Products
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly FileUploadService _fileUploadService;

        public ProductController(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public IActionResult Index()
        {
            var products = _dbContext.Products.AsNoTracking().ToList();

            var model = new ProductIndexVM
            {
                Products = products
            };

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Brands = await _dbContext.Brands.ToListAsync();
            ViewBag.Categories = await _dbContext.Categories.ToListAsync();
            ViewBag.Colors = await _dbContext.Color.ToListAsync();
            return View();
        }
        public IActionResult Add()
        {
            var categories = _dbContext.Categories.AsNoTracking().ToList();
            var color = _dbContext.Color.AsNoTracking().ToList();

            var model = new ProductAddVM
            {
                Categories = categories,
                Colors = color
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(ProductAddVM model)
        {

            var newProduct = new Entities.Product();

            newProduct.Name = model.Name;
            newProduct.Price = model.Price;

            var foundCategory = _dbContext.Categories.FirstOrDefault(x => x.Id == model.CategoryId);
            if (foundCategory is null) return View(model);

            var foundColor = _dbContext.Color.FirstOrDefault(x => x.Id == model.ColorId);
            if (foundColor is null) return View(model);

            newProduct.Category = foundCategory;

            newProduct.Color = foundColor;

            newProduct.Description= model.Description;

  
            _dbContext.Add(newProduct);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
