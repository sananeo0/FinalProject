using FinalProject.Data;
using FinalProject.Entities;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly AppDbContext _dbContext;
        public SubscriptionController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Subscribe(SubscriptionSubscribeVM model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            var existingEmail = _dbContext.Subscriptions.Any(x => x.Email == model.Email);
            if (existingEmail)
            {
                ModelState.AddModelError("Email", "This email is already subscribed.");
                return RedirectToAction(nameof(Index));
            }
            var subcription = new Subscription();

            subcription.Email = model.Email;

            _dbContext.Add(subcription);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
