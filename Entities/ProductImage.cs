using System.ComponentModel.DataAnnotations;

namespace FinalProject.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ImageId { get; set; }
        public Image Image { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Order must be a positive number.")]
        public int Order { get; set; }
    }
}
