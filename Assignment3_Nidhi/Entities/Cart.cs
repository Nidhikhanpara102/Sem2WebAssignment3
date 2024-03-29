using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Assignment3_Nidhi.Entities
{
    public class Cart
    {

        [Key]
        public int CartId { get; set; }

      
        public int ProductId { get; set; }

      
        public int UserId { get; set; }

        public int Quantities { get; set; }


    }
}
