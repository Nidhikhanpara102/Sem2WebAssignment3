using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment3_Nidhi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Assignment3_Nidhi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AssignmentDbContext _context;

        public OrderController(AssignmentDbContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            var orders = _context.Orders.ToList();

            if (orders.Count == 0)
            {
                var errorMessage = "No orders found";
                return NotFound(errorMessage);
            }

            return orders;
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = _context.Orders.Find(id);

            if (order == null)
            {
                return NotFound("Order Id does not found");
            }

            return order;
        }

        // POST: api/Order
        [HttpPost]
        public ActionResult<object> PostOrder(Order order)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                                .Select(e => e.ErrorMessage)
                                                .ToList();
                return BadRequest(errors);
            }

            _context.Orders.Add(order);
            _context.SaveChanges();

            var successMessage = "Order created successfully";
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, new { Order = order, Message = successMessage });
        }


        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                var errorMessage = "Invalid order ID";
                return BadRequest(errorMessage);
            }

            _context.Entry(order).State = EntityState.Modified;

            if (!_context.Orders.Any(o => o.OrderId == id))
            {
                var errorMessage = $"Order with ID {id} not found";
                return NotFound(errorMessage);
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            var successMessage = "Order updated successfully";
            return Ok(successMessage);
        }


        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public ActionResult<Order> DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                var errorMessage = $"Order with ID {id} not found";
                return NotFound(errorMessage);
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();

            var successMessage = $"Order with ID {id} has been deleted successfully";
            return Ok(new { message = successMessage, order });
        }
    }
}
