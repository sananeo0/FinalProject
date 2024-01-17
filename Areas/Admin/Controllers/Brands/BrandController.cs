using FinalProject.Areas.Admin.Models;
using FinalProject.Data;
using FinalProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Areas.Admin.Controllers.Brands
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BrandController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var brands = _dbContext.Brands.AsNoTracking().ToList();

            var model = new BrandIndexVM
            {
                Brands = brands
            };

            return View(model);
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
        public IActionResult Add(BrandAddVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var newBrand = new Brand();

            newBrand.Name = model.Name;

            _dbContext.Add(newBrand);


            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            var brand = _dbContext.Brands.FirstOrDefault(x => x.Id == id);

            if (brand is null) return NotFound();

            _dbContext.Remove(brand);

            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
         public IActionResult Update(int id)
        {
            var brand = _dbContext.Brands.FirstOrDefault(x => x.Id == id);

            if (brand is null) return NotFound();

            var model = new BrandUpdateVM
            {
                Id = brand.Id,
                Name = brand.Name
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(BrandUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingBrand = _dbContext.Brands.FirstOrDefault(x => x.Id == model.Id);

            if (existingBrand is null) return NotFound();

            existingBrand.Name = model.Name;

            _dbContext.Update(existingBrand);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
