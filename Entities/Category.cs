using System.ComponentModel.DataAnnotations;

namespace FinalProject.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
