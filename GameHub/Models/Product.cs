using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        // validation rules go directly above the property they check
        [MinLength (2, ErrorMessage = "Hey!  This is way too short!")]
        [MaxLength (100)]
        [Required]
        public string? Name { get; set; }

        [Range(0.01, 999999)]
        [DisplayFormat(DataFormatString = "{0:c}")]  // c is the MS current format code
        public decimal? Price { get; set; }

        public string? Photo { get; set; }

        // FK for Category
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        // ref to parent model
        public Category? Category { get; set; }

        // ref to child model - 1 product can be in many cartitems
        public List<CartItem>? CartItems { get; set; }

        // ref to 2nd child model - 1 product can be in many orderdetails (bought many times)
        public List<OrderDetail>? OrderDetails { get; set; }

        [Display(Name = "Release Year")]
        public int ReleaseYear { get; set; }

    }
}
