using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string? CustomerId { get; set; }

        [Required]
        public int ProductId { get; set; }

        // parent ref to Product - every cartitem is for only 1 product
        public Product? Product { get; set; }
    }
}
