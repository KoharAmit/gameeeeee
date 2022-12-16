using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        // parent ref - 1 order many orderdetails
        public Order? Order { get; set; }

        // 2nd parent ref - 1 product in many orderdetails
        public Product? Product { get; set; }

    }
}
