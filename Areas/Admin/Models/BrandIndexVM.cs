using FinalProject.Entities;

namespace FinalProject.Areas.Admin.Models
{
    public class BrandIndexVM
    {
        public int Id { get; set; }
        public List<Brand> Brands { get; set; }
    }
}
