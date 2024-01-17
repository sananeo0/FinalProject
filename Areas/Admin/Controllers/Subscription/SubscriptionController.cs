using FinalProject.Areas.Admin.Models;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Areas.Admin.Controllers.Email
{
    [Area("Admin")]
    public class SubscriptionController : Controller
    {
        private readonly AppDbContext _dbContext;

        public SubscriptionController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var emails = _dbContext.Subscriptions.AsNoTracking().Select(x => x.Email).ToList();

            var model = new SubscriptionIndexVM
            {
                Emails=emails
            };

            return View(model);
        }
    }
}
