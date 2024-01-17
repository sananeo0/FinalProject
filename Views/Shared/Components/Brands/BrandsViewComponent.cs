using FinalProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Views.Shared.Components.Brands
{
    public class BrandsViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(List<Brand> model)
        {
            return View(model);
        }
    }
}
