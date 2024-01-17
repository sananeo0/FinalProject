using FinalProject.Areas.Admin.Models;
using FinalProject.Data;
using FinalProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Areas.Admin.Controllers.Categories
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var categories = _dbContext.Categories.AsNoTracking().ToList();

            var model = new CategoryIndexVM
            {
                Categories = categories
            };

            return View(model);
        }

        public IActionResult Add()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Add(CategoryAddVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var newCategory = new Category();

            newCategory.Name = model.Name;

            _dbContext.Add(newCategory);


            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.Id == id);

            if (category is null) return NotFound();

            _dbContext.Remove(category);

            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(x => x.Id == id);

            if (category is null) return NotFound();

            var model = new CategoryUpdateVM
            {
                Id = category.Id,
                Name = category.Name
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(CategoryUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = _dbContext.Categories.FirstOrDefault(x => x.Id == model.Id);

            if (category is null) return NotFound();

            category.Name = model.Name;

            _dbContext.Update(category);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
