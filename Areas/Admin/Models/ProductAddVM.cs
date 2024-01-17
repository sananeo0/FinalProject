using FinalProject.Entities;

namespace FinalProject.Areas.Admin.Models
{
    public class ProductAddVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public decimal Price { get; set; }


        public bool InStock { get; set; }

        public string ImageId { get; set; }
        public List<ProductImage> ProductImages { get; set; }

        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }

        public int BrandID { get; set; }
        public Brand Brand { get; set; }

        public int ColorId { get; set; }
        public List <Color> Colors { get; set; }

        public IFormFile Image { get; set; }
    }
}
