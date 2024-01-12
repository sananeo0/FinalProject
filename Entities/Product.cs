using System.ComponentModel.DataAnnotations;

namespace FinalProject.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Product description is required.")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Product price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a valid price.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "It should consist of digits, and may include an optional decimal part with up to two digits.")]
        public decimal Price { get; set; }


        public bool InStock { get; set; }


        [Required(ErrorMessage = "Product image is required.")]
        public string ImageId { get; set; }
        public List<ProductImage> ProductImages { get; set; }


        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }


        [Required(ErrorMessage = "Product color is required.")]
        public int ColorId { get; set; }
        public Color Color { get; set; }


    }
}
