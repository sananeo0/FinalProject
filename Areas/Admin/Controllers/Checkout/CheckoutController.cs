using FinalProject.Areas.Admin.Models;
using FinalProject.Data;
using FinalProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Areas.Admin.Controllers.Checkout
{
    [Area("Admin")]
    public class CheckoutController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CheckoutController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var checkout = _dbContext.Checkouts.AsNoTracking().ToList();

            var model = new CheckoutIndexVM
            {
                FirstName = checkout.Select(s => s.FirstName).ToList(),
                LastName = checkout.Select(s => s.LastName).ToList(),
                CompanyName = checkout.Select(s => s.CompanyName).ToList(),
                Email = checkout.Select(s => s.Email).ToList(),
                Country = checkout.Select(s => s.Country).ToList(),
                Address = checkout.Select(s => s.Address).ToList(),
                Town = checkout.Select(s => s.Town).ToList(),
                ZipCode = checkout.Select(s => s.ZipCode).ToList(),
                PhoneNumber = checkout.Select(s => s.PhoneNumber).ToList(),
                Comment = checkout.Select(s => s.Comment).ToList(),
            };

            return View(model);
        }
    }
}
