using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment3_Nidhi.Entities;
using System.Collections.Generic;
using System.Linq;

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

        // GET: api/Cart
        [HttpGet]
        public ActionResult<IEnumerable<Cart>> GetCarts()
        {
            return _context.Carts.ToList();
        }

        // GET: api/Cart/5
        [HttpGet("{id}")]
        public ActionResult<Cart> GetCart(int id)
        {
            var cart = _context.Carts.Find(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // POST: api/Cart
        [HttpPost]
        public ActionResult<Cart> PostCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCart), new { id = cart.CartId }, cart);
        }

        // PUT: api/Cart/5
        [HttpPut("{id}")]
        public IActionResult PutCart(int id, Cart cart)
        {
            if (id != cart.CartId)
            {
                return BadRequest();
            }

            _context.Entry(cart).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Cart/5
        [HttpDelete("{id}")]
        public ActionResult<Cart> DeleteCart(int id)
        {
            var cart = _context.Carts.Find(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(cart);
            _context.SaveChanges();

            return cart;
        }
    }
}
