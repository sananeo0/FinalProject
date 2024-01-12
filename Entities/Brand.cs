using System.ComponentModel.DataAnnotations;

namespace FinalProject.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Brand name is required.")]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
