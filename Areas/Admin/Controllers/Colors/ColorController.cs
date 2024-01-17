using FinalProject.Areas.Admin.Models;
using FinalProject.Data;
using FinalProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Imaging;

namespace FinalProject.Areas.Admin.Controllers.Colors
{
    [Area("Admin")]
    public class ColorController:Controller
    {
        private readonly AppDbContext _dbContext;

        public ColorController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var colors = _dbContext.Color.AsNoTracking().ToList();

            var model = new ColorIndexVM
            {
                Colors = colors
            };


            return View(model);
        }

        public IActionResult Add()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Add(ColorAddVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var newColor = new Color();

            newColor.ColorCode = model.ColorCode;
            newColor.Name= model.Name;

            _dbContext.Add(newColor);


            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Delete(int id)
        {
            var color = _dbContext.Color.FirstOrDefault(x => x.Id == id);

            if (color is null) return NotFound();

            _dbContext.Remove(color);

            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            var color = _dbContext.Color.FirstOrDefault(x => x.Id == id);

            if (color is null) return NotFound();

            var model = new ColorUpdateVM
            {
                Id = color.Id,
                Name = color.Name
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Update(ColorUpdateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingColor = _dbContext.Color.FirstOrDefault(x => x.Id == model.Id);

            if (existingColor is null) return NotFound();

            existingColor.Name = model.Name;

            _dbContext.Update(existingColor);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
