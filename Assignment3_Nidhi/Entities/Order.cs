using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3_Nidhi.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public int UserId { get; set; }

        public DateTime OrderDate { get; set; }

        
    }
}
