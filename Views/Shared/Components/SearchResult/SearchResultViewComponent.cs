using FinalProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Views.Shared.Components.SearchResult
{
    public class SearchResultViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(List<Product> model)
        {
            return View(model);
        }
    }
}
