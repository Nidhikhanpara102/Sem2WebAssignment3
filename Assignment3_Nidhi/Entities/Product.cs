using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment3_Nidhi.Entities
{
    public class Product
    {
        public Product()
        {
            Comments = new List<Comments>();
            CartItems = new List<Cart>();
        }

        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Pricing is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Pricing must be a positive value")]
        public float Pricing { get; set; }

        [Required(ErrorMessage = "Shipping cost is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Shipping cost must be a positive value")]
        public float ShippingCost { get; set; }

        public ICollection<Comments> Comments { get; set; }

        public ICollection<Cart> CartItems { get; set; }
    }
}
