using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment3_Nidhi.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Assignment3_Nidhi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly AssignmentDbContext _context;

        public CartController(AssignmentDbContext context)
        {
            _context = context;
        }
        // POST: api/Cart
        [HttpPost]
        public ActionResult<Cart> PostCart(Cart cart)
        {
            var product = _context.Products.Find(cart.ProductId);
            if (product == null)
            {
                return BadRequest("Invalid ProductId");
            }

            _context.Carts.Add(cart);
            _context.SaveChanges();
            var successMessage = "Item added to the cart successfully";

            return CreatedAtAction(nameof(GetCart), new { id = cart.CartId }, new { cart, Message = successMessage });
        }



        // GET: api/Cart/5
        [HttpGet("{id}")]
        public ActionResult<Cart> GetCart(int id)
        {
            var cart = _context.Carts.Find(id);

            if (cart == null)
            {
                return NotFound("Cart Item id not found");
            }

            return cart;
        }


        // PUT: api/Cart/5
        [HttpPut("{id}")]
        public IActionResult PutCart(int id, Cart cart)
        {
            try
            {
                if (id != cart.CartId)
                {
                    var errorMessage = "Invalid Cart ID";
                    return BadRequest(errorMessage);
                }

                _context.Entry(cart).State = EntityState.Modified;
                _context.SaveChanges();

                var successMessage = "Cart updated successfully";
                return Ok(new { message = successMessage });
            }
            catch (Exception ex)
            {
                var errorMessage = "An error occurred while updating the cart";
                Console.WriteLine($"Error occurred: {ex.Message}");
                return BadRequest(errorMessage);
            }
        }
        // GET: api/Cart
        [HttpGet]
        public ActionResult<IEnumerable<Cart>> GetCarts()
        {
            var carts = _context.Carts.ToList();

            if (carts.Count == 0)
            {
                var errorMessage = "Cart is empty";
                return NotFound(errorMessage);
            }

            return carts;
        }


        // DELETE: api/Cart/5
        [HttpDelete("{id}")]
        public ActionResult<Cart> DeleteCart(int id)
        {
            var cart = _context.Carts.Find(id);
            if (cart == null)
            {
                var errorMessage = $"Cart with ID {id} not found";
                return NotFound(errorMessage);
            }

            _context.Carts.Remove(cart);
            _context.SaveChanges();

            var successMessage = $"Cart with ID {id} has been deleted successfully";
            return Ok(new { message = successMessage, cart });
        }

    }
}
