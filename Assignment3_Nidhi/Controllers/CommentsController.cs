using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment3_Nidhi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Assignment3_Nidhi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly AssignmentDbContext _context;

        public CommentsController(AssignmentDbContext context)
        {
            _context = context;
        }


        // GET: api/Comments
        [HttpGet]
        public ActionResult<IEnumerable<Comments>> GetComments()
        {
            return _context.Comments.ToList();
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public ActionResult<Comments> GetComments(int id)
        {
            var comments = _context.Comments.Find(id);

            if (comments == null)
            {
                return NotFound("Comment Id not found");
            }

            return comments;
        }

        // POST: api/Comments
        [HttpPost]
        public ActionResult<Comments> PostComments(Comments comments)
        {
            var product = _context.Products.Find(comments.ProductId);
            if (product == null)
            {
                return BadRequest("Invalid ProductId");
            }

            _context.Comments.Add(comments);
            _context.SaveChanges();

            var successMessage = "Comment added successfully";

            return CreatedAtAction(nameof(GetComments), new { id = comments.CommentId }, new { comments, message = successMessage });
        }


        // PUT: api/Comments/5
        [HttpPut("{id}")]
        public IActionResult PutComments(int id, Comments comments)
        {
            if (id != comments.CommentId)
            {
                return BadRequest("Invalid Comment ID");
            }

            var existingComment = _context.Comments.Find(id);
            if (existingComment == null)
            {
                return NotFound("Comment not found");
            }

            existingComment.ProductId = comments.ProductId;
            existingComment.UserId = comments.UserId;
            existingComment.Rating = comments.Rating;
            existingComment.Image = comments.Image;
            existingComment.Text = comments.Text;

            _context.Entry(existingComment).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok("Comment updated successfully");
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public ActionResult<Comments> DeleteComments(int id)
        {
            var comments = _context.Comments.Find(id);
            if (comments == null)
            {
                return NotFound("Comment not found");
            }

            _context.Comments.Remove(comments);
            _context.SaveChanges();

            var successMessage = $"Comment with id {id} has been deleted successfully";

            return Ok(successMessage);
        }


    }
}
