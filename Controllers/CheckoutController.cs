using FinalProject.Data;
using FinalProject.Entities;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class CheckoutController : Controller
    {
		private readonly AppDbContext _dbContext;
		public CheckoutController(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
        public IActionResult Submit(CheckoutSubmitVM model)
        {
			if (!ModelState.IsValid)
			{
				return View(model);
			}

            var newCheckout = new Checkout();

			newCheckout.FirstName = model.FirstName;
			newCheckout.LastName = model.LastName;
			newCheckout.Email = model.Email;
			newCheckout.Address = model.Address;
			newCheckout.Comment = model.Comment;
			newCheckout.CompanyName = model.CompanyName;
			newCheckout.Country= model.Country;
			newCheckout.ZipCode= model.ZipCode;
			newCheckout.Town = model.Town;
			newCheckout.PhoneNumber = model.PhoneNumber;

			_dbContext.Add(newCheckout);
			_dbContext.SaveChanges();

			return RedirectToAction(nameof(Index));
		}
	}
}
