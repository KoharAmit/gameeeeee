using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        // ref list of child Products
        public List<Product>? Products { get; set; }
    }
}
