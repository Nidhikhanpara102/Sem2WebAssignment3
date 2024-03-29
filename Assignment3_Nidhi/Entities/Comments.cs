using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3_Nidhi.Entities
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public float Rating { get; set; }

        public string Image { get; set; }

        public string Text { get; set; }

    }
}

