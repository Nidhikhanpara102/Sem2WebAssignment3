using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment3_Nidhi.Entities
{
    public class User
    {
        public User()
        {
            CartItems = new List<Cart>();
        }

        [Key]
        public int UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public string PurchaseHistory { get; set; }

        public string ShippingAddress { get; set; }

        public ICollection<Cart> CartItems { get; set; }
    }
}

