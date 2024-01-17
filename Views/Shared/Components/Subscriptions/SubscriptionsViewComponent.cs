using FinalProject.Data;
using FinalProject.Entities;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Views.Shared.Components.Subscriptions
{
    public class SubscriptionsViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(List<Subscription> model)
        {
            return View(model);
        }

    }
}
