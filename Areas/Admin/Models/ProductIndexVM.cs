using FinalProject.Entities;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Areas.Admin.Models
{
    public class ProductIndexVM
    {
        public List<Product> Products { get; set; }
      
    }
}
