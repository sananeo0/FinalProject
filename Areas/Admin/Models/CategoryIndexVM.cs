using FinalProject.Entities;

namespace FinalProject.Areas.Admin.Models
{
    public class CategoryIndexVM
    {
        public int Id { get; set; }
        public List<Category> Categories { get; set; }
    }
}
