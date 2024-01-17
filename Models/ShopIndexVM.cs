using FinalProject.Entities;

namespace FinalProject.Models
{
    public class ShopIndexVM
    {

        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Category> Categories { get; set; }
        public List<Color> Colors { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPageCount { get; set; }
        public int TotalProducts { get; set; }

    }
}
